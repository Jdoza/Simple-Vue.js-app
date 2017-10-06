using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartEx.Models.Response
{
    public abstract class baseResponse
    {
        public bool IsSuccessful { get; set; }
    }
}