// ===============================
// *******************************
// The startup class
// ===============================
// *******************************

using Microsoft.Owin;

[assembly: OwinStartupAttribute(typeof(MyShapeBody.Startup))]
namespace MyShapeBody
{
    using System.Data.Entity;

    using Owin;

    using AutoMapper;

    using BodyShapeData;

    public partial class Startup
    {
        /// <summary>
        /// The configuration profile method.
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            // Configuration
            ConfigureAuth(app);

            // Database initialization
            using (var db = new BodyShapeContext())
                db.Database.Initialize(true);
        }
    }
}
