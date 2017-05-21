// ===============================
// *******************************
// The body snapper interface.
// ===============================
// *******************************

namespace MyShapeBody.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using MyShapeBody.AppModels;

    /// <summary>
    /// The snapper inteface
    /// </summary>
    public interface IBodySnapper
    {
        bool SnapMorphoBody(BodyTicket bodyTicket);
    }
}