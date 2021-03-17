using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Util
{
    public class ResponseObject
    {
        public bool IsSuccess { get; set; }
        public string ExceptionMessage { get; set; }
    }
}
