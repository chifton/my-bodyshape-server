// ===============================
// *******************************
// The mail notificator class.
// ===============================
// *******************************

namespace BodyShapeNotifications.Impl
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;
    using System.Web;

    /// <summary>
    /// The mail notificator class. 
    /// </summary>
    public class MailNotificator : INotificator
    {
        /// <summary>
        /// The mail configuration
        /// </summary>
        public IMailConfiguration MailConfiguration { get; set; }

        /// <summary>
        /// The logo path.
        /// </summary>
        public string LogoPath { get; set; }

        /// <summary>
        /// The mail notificator constructor.
        /// </summary>
        public MailNotificator()
        {
            this.MailConfiguration = this.GetMailConfiguration();
            this.LogoPath = string.Empty;
        }

        /// <summary>
        /// The send method.
        /// </summary>
        /// <param name="html">the content.</param>
        /// <returns>The result.</returns>
        public bool Send(string htmlOrjson, string userMail, string username, string subject)
        {
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(this.MailConfiguration.SenderEmail, this.MailConfiguration.SenderName);
                message.To.Add(new MailAddress(userMail, username));
                message.Subject = subject;

                // Modify the content here with logo and others
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images"), "myshapebodymail.jpg");
                byte[] reader = File.ReadAllBytes(path);
                MemoryStream image = new MemoryStream(reader);
                var alternativeView = AlternateView.CreateAlternateViewFromString(htmlOrjson, Encoding.UTF8, MediaTypeNames.Text.Html);
                var logo = new LinkedResource(image, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                logo.ContentId = "mybodyshapelogo";
                logo.ContentType = new System.Net.Mime.ContentType("image/jpg");

                alternativeView.LinkedResources.Add(logo);
                message.AlternateViews.Add(alternativeView);


                using (var smtpClient = new SmtpClient(this.MailConfiguration.SmtpServerUrl, this.MailConfiguration.SmtpServerPort))
                {
                    smtpClient.Credentials = new NetworkCredential(this.MailConfiguration.SmtpServerUsername, this.MailConfiguration.SmtpServerPassword);
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(message);
                }

                return true;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("An error occured during mail sending.\t\n" + ex);
            }
        }

        /// <summary>
        /// The get mail configuration section.
        /// </summary>
        /// <returns>The mail configuration.</returns>
        private MailConfigurationSection GetMailConfiguration()
        {
            try
            {
                var mailConfig = ConfigurationManager.GetSection("mail") as MailConfigurationSection;
                return mailConfig;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occured during mail getting configuration.\t\n" + ex);
            }
        }
    }
}