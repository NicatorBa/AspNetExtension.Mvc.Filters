using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetExtension.Mvc.Filters
{
    public class ErrorResponse
    {
        public string Type { get; set; }

        public string Description { get; set; }

        public string Info { get; set; }

        public object ModelErrors { get; set; }
    }
}
