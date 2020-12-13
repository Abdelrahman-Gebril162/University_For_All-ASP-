using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Student
    {
        public int id { get; set; }
        public string st_fname { get; set; }
        public string st_lname { get; set; }
        public DateTime st_DateOfBirth { get; set; }
        public string st_address { get; set; }
        public string st_city { get; set; }
        public int st_phone { get; set; }
        public string st_email { get; set; }
        public string st_password { get; set; }
        public string st_confirmPassword { get; set; }
        public string st_picture { get; set; }
        public int st_level { get; set; }
        public bool Undergrad { get; set; }
        public DateTime enroll_date { get; set; }
        public Faculty Faculty { get; set; }
        public int FacultyId { get; set; }
    }
}