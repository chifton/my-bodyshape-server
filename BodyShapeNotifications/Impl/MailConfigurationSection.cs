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
        [ConfigurationProperty(PropertyNames.SmtpServerUrl, IsRequired = true)]
        public string SmtpServerUrl
        {
            get
            {
                return this[PropertyNames.SmtpServerUrl].ToString();
            }
            set
            {
                this[PropertyNames.SmtpServerUrl] = value;
            }
        }

        /// <summary>
        /// The SMTP server port.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SmtpServerPort, IsRequired = true)]
        public int SmtpServerPort
        {
            get
            {
                return Convert.ToInt32(this[PropertyNames.SmtpServerPort]);
            }
            set
            {
                this[PropertyNames.SmtpServerPort] = value;
            }
        }

        /// <summary>
        /// Th SMTP username.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SmtpServerUsername, IsRequired = true)]
        public string SmtpServerUsername
        {
            get
            {
                return this[PropertyNames.SmtpServerUsername].ToString();
            }
            set
            {
                this[PropertyNames.SmtpServerUsername] = value;
            }
        }

        /// <summary>
        /// Th SMTP password.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SmtpServerpassword, IsRequired = true)]
        public string SmtpServerPassword
        {
            get
            {
                return this[PropertyNames.SmtpServerpassword].ToString();
            }
            set
            {
                this[PropertyNames.SmtpServerpassword] = value;
            }
        }

        /// <summary>
        /// The sender email.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SenderEmail, IsRequired = true)]
        public string SenderEmail
        {
            get
            {
                return this[PropertyNames.SenderEmail].ToString();
            }
            set
            {
                this[PropertyNames.SenderEmail] = value;
            }
        }

        /// <summary>
        /// The sender name.
        /// </summary>
        [ConfigurationProperty(PropertyNames.SenderName, IsRequired = true)]
        public string SenderName
        {
            get
            {
                return this[PropertyNames.SenderName].ToString();
            }
            set
            {
                this[PropertyNames.SenderName] = value;
            }
        }

        /// <summary>
        /// The website url.
        /// </summary>
        [ConfigurationProperty(PropertyNames.WebsiteUrl, IsRequired = true)]
        public string WebSiteUrl
        {
            get
            {
                return this[PropertyNames.WebsiteUrl].ToString();
            }
            set
            {
                this[PropertyNames.WebsiteUrl] = value;
            }
        }

        /// <summary>
        /// The property names.
        /// </summary>
        public static class PropertyNames
        {
            /// <summary>
            /// The smtp server url.
            /// </summary>
            public const string SmtpServerUrl = "smtpserverurl";

            /// <summary>
            /// The smtp server port.
            /// </summary>
            public const string SmtpServerPort = "smtpserverport";

            /// <summary>
            /// The smtp username.
            /// </summary>
            public const string SmtpServerUsername = "smtpserverusername";

            /// <summary>
            /// The smtp password.
            /// </summary>
            public const string SmtpServerpassword = "smtpserverpassword";

            /// <summary>
            /// The sender email.
            /// </summary>
            public const string SenderEmail = "senderemail";

            /// <summary>
            /// The sender name.
            /// </summary>
            public const string SenderName = "sendername";

            /// <summary>
            /// The website url.
            /// </summary>
            public const string WebsiteUrl = "websiteurl";    
        }
    }
}
