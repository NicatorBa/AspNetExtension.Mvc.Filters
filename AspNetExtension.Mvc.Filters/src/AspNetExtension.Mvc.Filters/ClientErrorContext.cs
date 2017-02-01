using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetExtension.Mvc.Filters
{
    public class ClientErrorContext
    {
        private readonly ObjectResult _objectResult;

        public ClientErrorContext(ObjectResult objectResult)
        {
            _objectResult = objectResult;
        }

        public int StatusCode
        {
            get
            {
                return _objectResult.StatusCode.Value;
            }
            set
            {
                _objectResult.StatusCode = value;
            }
        }

        /// <summary>
        /// Gets the value or null if the type not matched.
        /// </summary>
        /// <typeparam name="TValue">The requested type.</typeparam>
        /// <returns></returns>
        public TValue TryGetValue<TValue>()
            where TValue : class
        {
            return _objectResult.Value as TValue;
        }

        /// <summary>
        /// Set the <see cref="MvcErrorModel"/> for this context.
        /// </summary>
        /// <param name="errorModel">The error model.</param>
        public void SetValue(MvcErrorModel errorModel)
        {
            if (errorModel == null)
            {
                throw new ArgumentNullException(nameof(errorModel));
            }

            _objectResult.Value = errorModel;
        }
    }
}
