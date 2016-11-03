// ===============================
// *******************************
// The mail configuration interface.
// ===============================
// *******************************

namespace BodyShapeNotifications
{
    /// <summary>
    /// The mail configuration interface.
    /// </summary>
    public interface IMailConfiguration
    {
        /// <summary>
        /// The SMTP server url.
        /// </summary>
        string SmtpServerUrl { get; set; }
        
        /// <summary>
        /// The SMTP server port.
        /// </summary>
        int SmtpServerPort { get; set; }

        /// <summary>
        /// The SMTP server username.
        /// </summary>
        string SmtpServerUsername { get; set; }
        
        /// <summary>
        /// The SMTP server password.
        /// </summary>
        string SmtpServerPassword { get; set; }

        /// <summary>
        /// The sender email.
        /// </summary>
        string SenderEmail { get; set; }

        /// <summary>
        /// The sender name.
        /// </summary>
        string SenderName { get; set; }

        /// <summary>
        /// The website url.
        /// </summary>
        string WebSiteUrl { get; set; }
    }
}
