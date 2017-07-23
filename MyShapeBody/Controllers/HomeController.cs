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
    using SystemIO = System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
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

    using Serilog;

    using MyShapeBody.Engine;
    using MyShapeBody.AppModels;
    using MyShapeBody.Services;
    using MyShapeBody.Configuration;
    using MyShapeBody.Configuration.Impl;
    using BodyShapeNotifications;
    using BodyShapeNotifications.Impl;

    public class HomeController : Controller
    {
        /// <summary>
        /// The bodyshape configuration
        /// </summary>
        private IBodyShapeConfiguration configuration;

        /// <summary>
        /// The body snapper
        /// </summary>
        private IBodySnapper bodySnapper;

        /// <summary>
        /// The body recorder
        /// </summary>
        private IBodyRecorder bodyRecorder;

        /// <summary>
        /// The mail notificator.
        /// </summary>
        private INotificator mailNotificator;

        /// <summary>
        /// The logger
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// The constructor
        /// </summary>
        public HomeController()
        {
            this.configuration = this.GetBodyShapeConfiguration();
            this.bodyRecorder = new BodyRecorder();
            this.bodySnapper = new BodySnapper(this.configuration.FolderLog);
            this.mailNotificator = new MailNotificator(this.configuration.FolderLog);
        }

        /// <summary>
        /// The initialize method.
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);

            var path = SystemIO.Path.Combine(Server.MapPath("~/" + this.configuration.FolderLog + ""), "bodyshape-{Date}.txt");
            this.logger = new LoggerConfiguration()
                .WriteTo.RollingFile(path, shared: true)
                .CreateLogger();
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
        /// Images loading from mobiles
        /// </summary>
        [HttpPost]
        public async Task<JsonResult> UploadFromMobile(string rootFileName)
        {
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                //foreach (string file in Request.Files)
                //{
                //    //var medre = Request.Files;
                //    var fileContent = Request.Files[file];
                //    if (fileContent != null && fileContent.ContentLength > 0)
                //    {
                //        var stream = fileContent.InputStream;
                //        var fileNameJson = rootFileName;

                //        var path = SystemIO.Path.Combine(Server.MapPath("~/Images/pictures_profiles"), fileNameJson);

                //        using (SystemIO.MemoryStream outStream = new SystemIO.MemoryStream())
                //        {
                //            using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                //            {
                //                imageFactory.Load(stream)
                //                            .Resize(new ResizeLayer(new Size(0, 600), ResizeMode.Pad))
                //                            .Quality(100)
                //                            .Save(outStream);
                //            }

                //            using (var fileOutStream = System.IO.File.Create(path))
                //            {
                //                outStream.CopyTo(fileOutStream);
                //            }
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                logger.Error($"An error occured during pictures upload\t\n{ ex }");
                return Json("Upload failed");
            }
            
            return Json(rootFileName, JsonRequestBehavior.AllowGet);
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

                            logger.Information("Registering photo N°1 with id " + id);
                        }
                        else if(order == "2")
                        {
                            fileName = MemoryCache.Default[id].ToString() + "Picture_2.png";
                            MemoryCache.Default.Remove(id);

                            logger.Information("Registering photo N°2 with id " + id);
                        }

                        fileNameJson = fileName;

                        var path = SystemIO.Path.Combine(Server.MapPath("~/Images/pictures_profiles"), fileName);

                        using (SystemIO.MemoryStream outStream = new SystemIO.MemoryStream())
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
                logger.Error($"An error occured during pictures upload\t\n{ ex }");
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
                var path = SystemIO.Path.Combine(Server.MapPath("~/Images/pictures_profiles"), filename);
                using (SystemIO.MemoryStream outStream = new SystemIO.MemoryStream())
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

                logger.Information($"Successfully flipped picture " + filename);
                return "OK";
            }
            catch(Exception ex)
            {
                logger.Error($"An error occured during pictures flip\t\n{ ex }");
                return "KO";
            }
        }

        /// <summary>
        /// Image rotation.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpGet]
        public string RotateImage(string filename, string sense)
        {
            try
            {
                var path = SystemIO.Path.Combine(Server.MapPath("~/Images/pictures_profiles"), filename);
                using (SystemIO.MemoryStream outStream = new SystemIO.MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(path)
                                    .Rotate(sense == "right" ? 90 : -90)
                                    .Save(outStream);
                    }

                    using (var fileOutStream = System.IO.File.Create(path))
                    {
                        outStream.CopyTo(fileOutStream);
                    }
                }

                logger.Information($"Successfully rotated picture " + filename);
                return "OK";
            }
            catch (Exception ex)
            {
                logger.Error($"An error occured during pictures rotation\t\n{ ex }");
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
            try
            {
                // Deserializing
                string json;
                using (var reader = new SystemIO.StreamReader(Request.InputStream))
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
                logger.Information($"Successfully generated body masses for id " + id);

                // Error calculation
                double? error = null;
                decimal decError = 0;
                bool toCompare = false;
                
                // For Android ans iOS weight values
                if(body.Weight == 0)
                {
                    body.Weight = null;
                }

                if (body.Weight.HasValue)
                {
                    error = result.BodyMass.TotalMass - body.Weight;
                    decError = Math.Round(decimal.Divide((decimal)error, (decimal)body.Weight) * 100, 2);
                    toCompare = true;
                }

                // Recording
                var user = User.Identity.IsAuthenticated ? User.Identity : null;
                this.bodyRecorder.RecordBody(body, result, decError, toCompare, user, User.Identity.IsAuthenticated, (decimal) this.configuration.MaxError);
                logger.Information($"Successfully registered body masses for id " + id);

                // Snaps client results
                var snapResult = this.bodySnapper.SnapMorphoBody(result);

                // Send to clients
                var jsonResult = string.Empty;
                if ((toCompare && Math.Abs(decError) <= this.configuration.MaxError) || !toCompare)
                {
                    // Serializing or not
                    jsonResult = snapResult ? JsonConvert.SerializeObject(result) : "Error";
                }
                else
                {
                    // Error message
                    jsonResult = "Error";
                }

                // Delete pictures
                var serverImagesPath = Server.MapPath("~/Images/pictures_profiles");
                var fileNameFront = SystemIO.Path.Combine(serverImagesPath, body.Picture_1);
                var fileNameSide = SystemIO.Path.Combine(serverImagesPath, body.Picture_2);
                SystemIO.File.Delete(fileNameFront);
                SystemIO.File.Delete(fileNameSide);

                // Returning to client
                logger.Information("Successfully returned body masses to client");
                return Json(jsonResult, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                logger.Error($"An error occured during masses generation\t\n{ ex }");
                throw new InvalidOperationException($"An error occured during masses generation\t\n{ ex }");
            }
        }

        /// <summary>
        /// Sends feedback mails.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void FeedBack(string mailContent)
        {
            // Send email
            var html = @"<html><body style='font-weight:bold;color:black;'>
                                     <p><span style='text-decoration:underline;'>Comment from a new user</span> :<br/><br/>" + mailContent + "</p></body></html>";
            var mail = mailNotificator.AutoSend(html, "User feedback !");

            logger.Information("A client feedback was sent");
        }

        /// <summary>
        /// Simulations number.
        /// </summary>
        [HttpGet]
        public int GetSimulationsNumber()
        {
            var dataTotalNumber = bodyRecorder.GetSimulationsNumber();
            return dataTotalNumber == 0 ? 10000 : dataTotalNumber;
        }

        /// <summary>
        /// Gets MyBodyShape url.
        /// </summary>
        [HttpGet]
        public string GetMyBodyShapeUrl()
        {
            var request = System.Web.HttpContext.Current.Request;
            return $"{request.Url.Scheme}://{ request.Url.Authority }";
        }

        /// <summary>
        /// Gets MyBodyShape privacy policy url.
        /// </summary>
        [HttpGet]
        public string GetMyBodyShapePrivacyPolicyUrl()
        {
            var request = System.Web.HttpContext.Current.Request;
            return $"{request.Url.Scheme}://{ request.Url.Authority }/Static/PrivacyPolicy.html";
        }

        /// <summary>
        /// The download snap results image method.
        /// </summary>
        [HttpGet]
        public ActionResult DownloadSnapResult(string id, int height)
        {
            try
            {
                var dir = Server.MapPath("/Images/snaps");
                var path = SystemIO.Path.Combine(dir, "snap_" + id + ".png");
                var resizedDir = Server.MapPath("/Images/snaps/resized");
                var resizedImagePath = SystemIO.Path.Combine(resizedDir, "snap_resized_" + id + ".png");
                
                using (SystemIO.MemoryStream outStream = new SystemIO.MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        imageFactory.Load(path)
                                    .Resize(new ResizeLayer(new Size(0, height), ResizeMode.Pad))
                                    .Quality(100)
                                    .Save(outStream);
                    }

                    using (var fileOutStream = System.IO.File.Create(resizedImagePath))
                    {
                        outStream.CopyTo(fileOutStream);
                    }

                    logger.Information($"Successfully resized snap picture with id " + id);

                    return base.File(resizedImagePath, "image/png");
                }
            }
            catch (Exception ex)
            {
                logger.Error($"An error occured during resizing picture with id { id }\t\n{ ex }");
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
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