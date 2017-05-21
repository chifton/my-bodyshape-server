// ===============================
// *******************************
// The body recorder class.
// ===============================
// *******************************

namespace MyShapeBody.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Security.Principal;

    using Microsoft.AspNet.Identity;

    using AutoMapper;

    using MyShapeBody.Mapping;
    using BodyShapeData;
    using Entities = BodyShapeData.Entities;
    using Models = MyShapeBody.AppModels;

    /// <summary>
    /// The recorder class
    /// </summary>
    public class BodyRecorder : IBodyRecorder
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private IMapper mapper;

        /// <summary>
        /// The mapper configuration.
        /// </summary>
        public static MapperConfiguration mapperConfig;

        /// <summary>
        /// The database context.
        /// </summary>
        private BodyShapeContext dbContext;

        /// <summary>
        /// The constructor.
        /// </summary>
        public BodyRecorder()
        {
            this.dbContext = new BodyShapeContext();

            // Automapper
            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<BodyMapProfile>();
            });
            this.mapper = mapperConfig.CreateMapper();
        }

        /// <summary>
        /// The record body method
        /// </summary>
        /// <param name="body">The body.</param>
        /// <param name="bodyTicket">The body ticket.</param>
        /// <param name="decError">The error.</param>
        /// <param name="toCompare">The compare to boolean.</param>
        public void RecordBody(Models.Body body, Models.BodyTicket bodyTicket, decimal decError, bool toCompare, IIdentity user, bool hasAccountNow)
        {
            var schema = this.mapper.Map<Entities.BodySchema>(body);
            var result = this.mapper.Map<Entities.BodyResult>(bodyTicket.BodyMass);
            bool? boolean = null;
            double? doublan = null;

            var id = Guid.NewGuid();

            var generation = new Entities.Generation
            {
                Id = id,
                UserId = user == null ? null : user.GetUserId(),
                HasAccount = hasAccountNow,
                AnonymousId = Guid.NewGuid(),
                GenerationDate = DateTime.Now,
                Success = toCompare ? (decError <= 5 ? true : false) : boolean,
                ErrorPercent = toCompare ? Convert.ToDouble(decimal.Divide(decError, 100)) : doublan,
                FrontPicture = schema.Picture_1,
                SidePicture = schema.Picture_2,
                Height = schema.Height,
                ExpectedWeight = schema.Weight,
                GeneratedWeight = result.TotalMass,
                BodySchema = schema,
                BodyResult = result
            };

            schema.Id = generation.Id;
            result.Id = generation.Id;

            dbContext.Generations.Add(generation);
            dbContext.SaveChanges();
        }
    }
}