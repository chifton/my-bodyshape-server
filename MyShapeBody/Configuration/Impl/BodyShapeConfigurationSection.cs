// ===============================
// *******************************
// The bodyshape configuration section class.
// ===============================
// *******************************

namespace MyShapeBody.Configuration.Impl
{
    using System;
    using System.Configuration;

    /// <summary>
    /// The bodyshape configuration section class.
    /// </summary>
    public class BodyShapeConfigurationSection : ConfigurationSection, IBodyShapeConfiguration
    {
        /// <summary>
        /// The common density.
        /// </summary>
        [ConfigurationProperty(PropertyNames.Density, IsRequired = true)]
        public decimal Density
        {
            get
            {
                return Convert.ToDecimal(this[PropertyNames.Density]);
            }
            set
            {
                this[PropertyNames.Density] = value;
            }
        }

        /// <summary>
        /// The maximum error percentage.
        /// </summary>
        [ConfigurationProperty(PropertyNames.MaxError, IsRequired = true)]
        public int MaxError
        {
            get
            {
                return Convert.ToInt32(this[PropertyNames.MaxError]);
            }
            set
            {
                this[PropertyNames.MaxError] = value;
            }
        }

        /// <summary>
        /// The property names.
        /// </summary>
        public static class PropertyNames
        {
            /// <summary>
            /// The common density.
            /// </summary>
            public const string Density = "density";

            /// <summary>
            /// The maximum error percentage.
            /// </summary>
            public const string MaxError = "maxerror";
        }
    }
}
