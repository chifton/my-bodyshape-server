// ===============================
// *******************************
// The ANDROID notificator class.
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
    /// The ANDROID notificator class. 
    /// </summary>
    public class AndroidNotificator : INotificator
    {
        /// <summary>
        /// The ANDROID notificator constructor.
        /// </summary>
        public AndroidNotificator()
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
    }
}