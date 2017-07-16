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
    using System.Security.Principal;

    using MyShapeBody.AppModels;

    /// <summary>
    /// The recorder inteface
    /// </summary>
    public interface IBodyRecorder
    {
        /// <summary>
        /// The record body method.
        /// </summary>
        void RecordBody(Body body, BodyTicket bodyTicket, decimal decError, bool toCompare, IIdentity user, bool hasAccountNow, decimal maxError);

        /// <summary>
        /// The get simulations number method.
        /// </summary>
        int GetSimulationsNumber();
    }
}