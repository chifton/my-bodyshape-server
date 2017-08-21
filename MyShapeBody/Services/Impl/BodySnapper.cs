// ===============================
// *******************************
// The body snapper class.
// ===============================
// *******************************

namespace MyShapeBody.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Drawing;
    using System.Drawing.Text;

    using ImageProcessor;
    using ImageProcessor.Imaging;

    using Serilog;

    using Models = MyShapeBody.AppModels;
    using MyBodyShape.Languages;

    /// <summary>
    /// The snapper class
    /// </summary>
    public class BodySnapper : IBodySnapper
    {
        /// <summary>
        /// The logger
        /// </summary>
        private ILogger logger;

        /// <summary>
        /// The results font family.
        /// </summary>
        private FontFamily resultsFontFamily;

        /// <summary>
        /// The watermarks models
        /// </summary>
        private List<Models.SnapModel> watermarksModels;

        /// <summary>
        /// The constructor
        /// </summary>
        public BodySnapper(string logFolder)
        {
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + logFolder + ""), "bodyshape-{Date}.txt");
            this.logger = new LoggerConfiguration()
                .WriteTo.RollingFile(path, shared: true)
                .CreateLogger();

            watermarksModels = new List<Models.SnapModel>();
            watermarksModels.Add(new Models.SnapModel("Head", Resources.Res_Head, new Point(347, 42)));
            watermarksModels.Add(new Models.SnapModel("Neck;Thorax", Resources.Res_Chest, new Point(353, 112)));
            watermarksModels.Add(new Models.SnapModel("Abdomen", Resources.Res_Abdomen, new Point(347, 246)));
            watermarksModels.Add(new Models.SnapModel("Bottom", Resources.Res_Bottom, new Point(345, 355)));

            watermarksModels.Add(new Models.SnapModel("ThighLeft", Resources.Res_ThighLeft, new Point(320, 468)));
            watermarksModels.Add(new Models.SnapModel("ThighRight", Resources.Res_ThighRight, new Point(35, 466)));
            watermarksModels.Add(new Models.SnapModel("LegLeft", Resources.Res_LegLeft, new Point(320, 616)));
            watermarksModels.Add(new Models.SnapModel("LegRight", Resources.Res_LegRight, new Point(40, 611)));
            watermarksModels.Add(new Models.SnapModel("FootLeft", Resources.Res_FootLeft, new Point(315, 698)));
            watermarksModels.Add(new Models.SnapModel("FootRight", Resources.Res_FootRight, new Point(40, 700)));

            watermarksModels.Add(new Models.SnapModel("ArmLeft", Resources.Res_ArmLeft, new Point(350, 168)));
            watermarksModels.Add(new Models.SnapModel("ArmRight", Resources.Res_ArmRight, new Point(5, 178)));
            watermarksModels.Add(new Models.SnapModel("ForeArmLeft", Resources.Res_ForeArmLeft, new Point(353, 315)));
            watermarksModels.Add(new Models.SnapModel("ForeArmRight", Resources.Res_ForeArmRight, new Point(5, 314)));
            watermarksModels.Add(new Models.SnapModel("HandLeft", Resources.Res_HandLeft, new Point(340, 424)));
            watermarksModels.Add(new Models.SnapModel("HandRight", Resources.Res_HandRight, new Point(5, 424)));

            // Font family
            resultsFontFamily = this.LoadFont(Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/fonts"), "GARABD.TTF"));
        }

        /// <summary>
        /// The snap body method
        /// </summary>
        public bool SnapMorphoBody(Models.BodyTicket bodyTicket)
        {
            try
            {
                // Watermarks
                var watermarks = this.BuildWatermarks(bodyTicket);

                var morphoPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/examples"), "morphoResult.png");
                var snapPath = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Images/snaps"), "snap_" + bodyTicket.Ticket + ".png");
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        var temImgFactory = imageFactory.Load(morphoPath);
                        foreach(var layer in watermarks)
                        {
                            temImgFactory.Watermark(layer);
                        }
                        temImgFactory.Save(outStream);
                    }
                    
                    using (var fileOutStream = System.IO.File.Create(snapPath))
                    {
                        outStream.CopyTo(fileOutStream);
                    }
                }

                logger.Information($"Successfully snapped results for generation id " + bodyTicket.Ticket);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error($"An error occured during snapping results for id { bodyTicket.Ticket }\t\n{ ex }");
                return false;
            }
        }

        /// <summary>
        /// The build watermarks method.
        /// </summary>
        private List<ImageProcessor.Imaging.TextLayer> BuildWatermarks(Models.BodyTicket bodyTicket)
        {
            var watermarks = new List<ImageProcessor.Imaging.TextLayer>();

            // Try pencil
            watermarks.Add(new TextLayer
            {
                Text = "TEST",
                FontColor = Color.White,
                FontSize = 11,
                Opacity = 1,
                FontFamily = resultsFontFamily,
                //Style = FontStyle.Bold,
                //Position = new Point(0, 0),
                DropShadow = false
            });

            var type = bodyTicket.BodyMass.GetType();
            foreach (var watermark in this.watermarksModels)
            {
                var splitMembers = watermark.MemberName.Split(';');
                double cumulativeMass = 0;
                foreach (var memb in splitMembers)
                {
                    if (!string.IsNullOrEmpty(memb) && !string.IsNullOrWhiteSpace(memb))
                    {
                        cumulativeMass += Convert.ToDouble(((Models.IShapeMass) type.GetProperty(memb).GetValue(bodyTicket.BodyMass)).Mass);
                    }
                }

                // Center
                var newText = string.Empty;
                var oldText = $"{ watermark.LabelText }\n{ cumulativeMass }kg -> { Math.Round((double)cumulativeMass / bodyTicket.BodyMass.TotalMass * 100, 0) }%";
                var textSplits = oldText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                var spacesGapCount = (int) Math.Floor((double) (Math.Abs(textSplits.Last().Length - textSplits.First().Length) / 2));
                var spaceSpaces = string.Empty;
                for(int f = 0; f < spacesGapCount; f++)
                {
                    spaceSpaces += " ";
                }
                if(textSplits.Last().Length > textSplits.First().Length)
                {
                    newText = $"{ spaceSpaces }{ watermark.LabelText }\n{ cumulativeMass }kg -> { Math.Round((double)cumulativeMass / bodyTicket.BodyMass.TotalMass * 100, 0) }%";
                }
                else if(textSplits.Last().Length < textSplits.First().Length)
                {
                    newText = $"{ watermark.LabelText }\n{ spaceSpaces }{ cumulativeMass }kg -> { Math.Round((double)cumulativeMass / bodyTicket.BodyMass.TotalMass * 100, 0) }%";
                }
                else
                {
                    newText = $"{ watermark.LabelText }\n{ cumulativeMass }kg -> { Math.Round((double)cumulativeMass / bodyTicket.BodyMass.TotalMass * 100, 0) }%";
                }

                // Add watermark layer
                watermarks.Add(new TextLayer
                {
                    Text = newText,
                    FontColor = Color.White,
                    FontSize = 10,
                    FontFamily = resultsFontFamily,
                    Style = FontStyle.Bold,
                    Position = watermark.Position,
                    DropShadow = false
                });
            }

            // Adjust percentages
            //var percentagesSum = watermarks.Where(p => p.Text != "TEST").Select(r => Convert.ToInt32(r.Text.Split('%')[0].Split(' ').Last())).Sum();
            //if (percentagesSum != 100)
            //{
            //    if(percentagesSum > 100)
            //    {
            //        var maximumPercentage = watermarks.Where(p => p.Text != "TEST").Select(r => Convert.ToInt32(r.Text.Split('%')[0].Split(' ').Last())).Max();
            //        var maximumElements = watermarks.Where(p => p.Text != "TEST").Where(r => Convert.ToInt32(r.Text.Split('%')[0].Split(' ').Last()) == maximumPercentage).ToList();
            //        if(maximumElements.Count == 1)
            //        {
            //            var element = maximumElements.FirstOrDefault();
            //            var index = watermarks.IndexOf(element);
            //            watermarks.ElementAt(index).Text = element?.Text.Replace(maximumPercentage.ToString(), (maximumPercentage - (percentagesSum - 100)).ToString());
            //        }
            //        else if(maximumElements.Count > 1)
            //        {
            //            var gap = Math.Floor((double) (percentagesSum - 100) / maximumElements.Count);
            //            foreach(var el in maximumElements)
            //            {
            //                var index = watermarks.IndexOf(el);
            //                watermarks.ElementAt(index).Text = el?.Text.Replace(maximumPercentage.ToString(), (maximumPercentage - (gap == 0 ? Math.Floor((double)(percentagesSum - 100)) : gap)).ToString());
            //                if(gap == 0)
            //                {
            //                    break; // Soustract only for the first element
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        var minimumPercentage = watermarks.Where(p => p.Text != "TEST").Select(r => Convert.ToInt32(r.Text.Split('%')[0].Split(' ').Last())).Min();
            //        var minimumElements = watermarks.Where(p => p.Text != "TEST").Where(r => Convert.ToInt32(r.Text.Split('%')[0].Split(' ').Last()) == minimumPercentage).ToList();
            //        if (minimumElements.Count == 1)
            //        {
            //            var element = minimumElements.FirstOrDefault();
            //            var index = watermarks.IndexOf(element);
            //            watermarks.ElementAt(index).Text = element?.Text.Replace(minimumPercentage.ToString(), (minimumPercentage + (100 - percentagesSum)).ToString());
            //        }
            //        else if (minimumElements.Count > 1)
            //        {
            //            var gap = Math.Floor((double)(100 - percentagesSum) / minimumElements.Count);
            //            foreach (var el in minimumElements)
            //            {
            //                var index = watermarks.IndexOf(el);
            //                watermarks.ElementAt(index).Text = el?.Text.Replace(minimumPercentage.ToString(), (minimumPercentage + (gap == 0 ? Math.Floor((double)(100 - percentagesSum)) : gap)).ToString());
            //                if (gap == 0)
            //                {
            //                    break; // Add only for the first element
            //                }
            //            }
            //        }
            //    }
            //}
            
            return watermarks;
        }

        /// <summary>
        /// The load font method.
        /// </summary>
        private FontFamily LoadFont(string fileName)
        {
            var fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(fileName);
            return fontCollection.Families[0];
        }
    }
}