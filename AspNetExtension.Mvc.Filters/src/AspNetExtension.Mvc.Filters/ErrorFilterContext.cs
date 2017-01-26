using Microsoft.AspNetCore.Mvc;
using System;

namespace AspNetExtension.Mvc.Filters
{
    public class ErrorFilterContext
    {
        private readonly ObjectResult _objectResult;

        public ErrorFilterContext(ObjectResult objectResult)
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

        public TValue TryGetValue<TValue>()
            where TValue : class
        {
            return _objectResult.Value as TValue;
        }

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
