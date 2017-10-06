using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartEx.Domain
{
    public class jobs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Salary { get; set; }
        public string Location { get; set; }
        public string ContactInfo { get; set; }
    }
}