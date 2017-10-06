using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartEx.Models.Response
{
    public class SuccessResponse : baseResponse
    {
        public SuccessResponse()
        {

            this.IsSuccessful = true;
        }
    }
}