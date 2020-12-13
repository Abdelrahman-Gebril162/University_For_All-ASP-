using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Faculty Faculty { get; set; }
        public int Facultyid { get; set; }
    }
}