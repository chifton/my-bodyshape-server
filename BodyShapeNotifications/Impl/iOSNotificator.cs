// ===============================
// *******************************
// The iOS notificator class.
// ===============================
// *******************************

namespace BodyShapeNotifications.Impl
{
    using System;
    using System.Configuration;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;

    /// <summary>
    /// The iOS notificator class. 
    /// </summary>
    public class iOSNotificator : INotificator
    {
        /// <summary>
        /// The iOS notificator constructor.
        /// </summary>
        public iOSNotificator()
        {

        }

        /// <summary>
        /// The send method.
        /// </summary>
        /// <param name="html">the content.</param>
        /// <returns>The result.</returns>
        public bool Send(string htmlOrjson, string userMail, string username, string subject)
        {
            return true;
        }

        /// <summary>
        /// The auto send method.
        /// </summary>
        /// <param name="html">the content.</param>
        /// <returns>The result.</returns>
        public bool AutoSend(string htmlOrjson, string subject)
        {
            return true;
        }
    }
}