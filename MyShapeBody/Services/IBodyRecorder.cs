// ===============================
// *******************************
// The body recorder interface.
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
    /// The recorder inteface
    /// </summary>
    public interface IBodyRecorder
    {
        void RecordBody(Body body, BodyTicket bodyTicket);
    }
}