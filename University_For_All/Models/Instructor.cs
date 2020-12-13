using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Instructor
    {
        public int id { get; set; }
        public string ints_fname { get; set; }
        public string inst_lname { get; set; }
        public string ints_email { get; set; }
        public string inst_password { get; set; }
        public string inst_confirmPassword { get; set; }
        public string inst_picture { get; set; }
        
        public Rank Rank { get; set; }
        public int Rankid { get; set; }
    }
}