// ===============================
// *******************************
// The home and only controller for the moment.
// ===============================
// *******************************

namespace MyShapeBody.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Runtime.Caching;
    using System.Configuration;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using Newtonsoft.Json;

    using ImageProcessor;
    using ImageProcessor.Imaging;

    using MyShapeBody.Engine;
    using MyShapeBody.AppModels;
    using MyShapeBody.Services;
    using MyShapeBody.Configuration;
    using MyShapeBody.Configuration.Impl;

    public class HomeController : Controller
    {
        /// <summary>
        /// The bodyshape configuration
        /// </summary>
        private IBodyShapeConfiguration configuration;

        /// <summary>
        /// The body recorder
        /// </summary>
        private BodyRecorder bodyRecorder;

        /// <summary>
        /// The constructor
        /// </summary>
        public HomeController()
        {
            this.bodyRecorder = new BodyRecorder();
            this.configuration = this.GetBodyShapeConfiguration();
        }

        /// <summary>
        /// Page d'accueil
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// About
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contact
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Image loading.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UploadFile(string id, string order)
        {
            var fileNameJson = string.Empty;

            try
            {
                foreach (string file in Request.Files)
                {
                    var fileContent = Request.Files[file];
                    if (fileContent != null && fileContent.ContentLength > 0)
                    {
                        var fileName = string.Empty;

                        var stream = fileContent.InputStream;

                        if (order == "1")
                        {
                            var customDate = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day;
                            var root = Guid.NewGuid().ToString() + "-" + customDate;
                            fileName = root + "Picture_1.png";
                            MemoryCache.Default[id] = root;
                        }
                        else if(order == "2")
                        {
                            fileName = MemoryCache.Default[id].ToString() + "Picture_2.png";
                            MemoryCache.Default.Remove(id);
                        }

                        fileNameJson = fileName;

                        var path = Path.Combine(Server.MapPath("~/Images/pictures_profiles"), fileName);

                        using (MemoryStream outStream = new MemoryStream())
                        {
                            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                            {
                                imageFactory.Load(stream)
                                            .Resize(new ResizeLayer(new Size(0, 600), ResizeMode.Pad))
                                            .Quality(100)
                                            .Save(outStream);
                            }

                            using (var fileOutStream = System.IO.File.Create(path))
                            {
                                    outStream.CopyTo(fileOutStream);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Upload failed");
            }

            return Json(fileNameJson, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Image flip.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public string FlipImage(string filename)
        {      
            try
            {
                var path = Path.Combine(Server.MapPath("~/Images/pictures_profiles"), filename);
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(path)
                                    .Flip(false)
                                    .Save(outStream);
                    }

                    using (var fileOutStream = System.IO.File.Create(path))
                    {
                        outStream.CopyTo(fileOutStream);
                    }
                }

                return "OK";
            }
            catch(Exception ex)
            {
                return "KO";
            }
        }

        /// <summary>
        /// Get and make model.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Calculate()
        {
            // Deserializing
            string json;
            using (var reader = new StreamReader(Request.InputStream))
            {
                json = reader.ReadToEnd();
            }
            var jsonObject = JsonConvert.DeserializeObject(json);

            // Generating
            var bodyGenerator = new BodyGenerator();
            var body = bodyGenerator.GenerateBody(jsonObject);
            var id = Guid.NewGuid();
            var calculator = new BodyCalculator(id, body);
            var result = calculator.GenerateBodyMasses(this.configuration.Density);

            // Error calculation
            double? error = null;
            decimal decError = 0;
            bool toCompare = false;
            if (body.Weight.HasValue)
            {
                error = result.BodyMass.TotalMass - body.Weight;
                decError = Math.Round(decimal.Divide((decimal) error, (decimal) body.Weight) * 100, 2);
                toCompare = true;
            }

            // Recording
            var user = User.Identity.IsAuthenticated ? User.Identity.GetUserName() : string.Empty;
            this.bodyRecorder.RecordBody(body, result, decError, toCompare, user, User.Identity.IsAuthenticated);

            // Send to clients
            var jsonResult = string.Empty;
            if ((toCompare && Math.Abs(decError) <= this.configuration.MaxError) || !toCompare)
            {
                // Serializing
                jsonResult = JsonConvert.SerializeObject(result.BodyMass);
            }
            else
            {
                // Error message
                jsonResult = "Error";
            }
            
            // Returning to client
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// The get bodyshape configuration method.
        /// </summary>
        /// <returns></returns>
        private BodyShapeConfigurationSection GetBodyShapeConfiguration()
        {
            try
            {
                var config = ConfigurationManager.GetSection("bodyshape") as BodyShapeConfigurationSection;
                return config;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occured during getting bodyshape configuration.\t\n" + ex);
            }
        }
    }
}