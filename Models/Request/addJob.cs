using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartEx.Models.Request
{
    public class addJob
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string ContactInfo { get; set; }
    }
}