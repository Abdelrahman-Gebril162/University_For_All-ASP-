using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Course
    {
        public int id { get; set; }
        public string cr_title { get; set; }
        public int cr_credit_hours { get; set; }
        public int cr_term { get; set; }
        public int cr_level { get; set; }
        public Faculty Faculty { get; set; }
        public int Facultyid { get; set; }
        public Instructor Instructor { get; set; }
        public int Instructorid { get; set; }

    }
}