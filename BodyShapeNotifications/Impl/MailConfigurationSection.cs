// ===============================
// *******************************
// The mail configuration section class.
// ===============================
// *******************************

namespace BodyShapeNotifications.Impl
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The mail configuration section class.
    /// </summary>
    public class MailConfigurationSection : ConfigurationSection, IMailConfiguration
    {
        /// <summary>
        /// The SMTP server url.
        /// </summary>
        [ConfigurationProperty("smtpserverurl", IsRequired = true)]
        public string SmtpServerUrl
        {
            get
            {
                return this["smtpserverurl"].ToString();
            }
            set
            {
                this["smtpserverurl"] = value;
            }
        }

        /// <summary>
        /// The SMTP server port.
        /// </summary>
        [ConfigurationProperty("smtpserverport", IsRequired = true)]
        public int SmtpServerPort
        {
            get
            {
                return Convert.ToInt32(this["smtpserverport"]);
            }
            set
            {
                this["smtpserverport"] = value;
            }
        }

        /// <summary>
        /// Th SMTP username.
        /// </summary>
        [ConfigurationProperty("smtpserverusername", IsRequired = true)]
        public string SmtpServerUsername
        {
            get
            {
                return this["smtpserverusername"].ToString();
            }
            set
            {
                this["smtpserverusername"] = value;
            }
        }

        /// <summary>
        /// Th SMTP password.
        /// </summary>
        [ConfigurationProperty("smtpserverpassword", IsRequired = true)]
        public string SmtpServerPassword
        {
            get
            {
                return this["smtpserverpassword"].ToString();
            }
            set
            {
                this["smtpserverpassword"] = value;
            }
        }

        /// <summary>
        /// The sender email.
        /// </summary>
        [ConfigurationProperty("senderemail", IsRequired = true)]
        public string SenderEmail
        {
            get
            {
                return this["senderemail"].ToString();
            }
            set
            {
                this["senderemail"] = value;
            }
        }

        /// <summary>
        /// The sender name.
        /// </summary>
        [ConfigurationProperty("sendername", IsRequired = true)]
        public string SenderName
        {
            get
            {
                return this["sendername"].ToString();
            }
            set
            {
                this["sendername"] = value;
            }
        }

        /// <summary>
        /// The website url.
        /// </summary>
        [ConfigurationProperty("websiteurl", IsRequired = true)]
        public string WebSiteUrl
        {
            get
            {
                return this["websiteurl"].ToString();
            }
            set
            {
                this["websiteurl"] = value;
            }
        }
    }
}

