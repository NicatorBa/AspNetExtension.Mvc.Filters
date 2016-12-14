using System.Collections.Generic;

namespace AspNetExtension.Mvc.Filters
{
    /// <summary>
    /// Represents a global error model for all controller actions.
    /// </summary>
    public class MvcErrorModel
    {
        /// <summary>
        /// The type of this error. For example 'ModelInvalid'.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// An additional description to handle this type of error.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// An Url to the Api-documentation.
        /// </summary>
        public string Info { get; set; }

        /// <summary>
        /// Listed errors if the given model is invalid.
        /// </summary>
        public IDictionary<string, ICollection<string>> ModelErrors { get; set; }
    }
}
