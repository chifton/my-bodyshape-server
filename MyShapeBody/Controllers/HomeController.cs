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
    using System.IO;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    using Newtonsoft.Json;

    using ImageProcessor;

    using MyShapeBody.Engine;
    using MyShapeBody.AppModels;
    using MyShapeBody.Services;

    public class HomeController : Controller
    {
        /// <summary>
        /// The body recorder
        /// </summary>
        private BodyRecorder bodyRecorder;

        /// <summary>
        /// The constructor
        /// </summary>
        public HomeController()
        {
            bodyRecorder = new BodyRecorder();
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

                        if(order == "1")
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
                        using (var fileStream = System.IO.File.Create(path))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }
            catch (Exception)
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
            var result = calculator.GenerateBodyMasses();

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
            if ((toCompare && decError <= 5) || !toCompare)
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
    }
}