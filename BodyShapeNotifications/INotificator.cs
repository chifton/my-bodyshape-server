// ===============================
// *******************************
// The notificator interface.
// ===============================
// *******************************

namespace BodyShapeNotifications
{
    /// <summary>
    /// The notificator interface.
    /// </summary>
    public interface INotificator
    {
        /// <summary>
        /// The send method.
        /// </summary>
        /// <returns>The result</returns>
        bool Send(string htmlOrjson, string userMail, string username, string subject);

        /// <summary>
        /// The auto send method.
        /// </summary>
        /// <returns>The result</returns>
        bool AutoSend(string htmlOrjson, string subject);
    }
}
