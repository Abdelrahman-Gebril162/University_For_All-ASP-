using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Course
    {
        public int id { get; set; }
        [Required]
        public string cr_title { get; set; }
        [Required]
        [Range(1,3)]
        public int cr_credit_hours { get; set; }
        [Required]
        [Range(1,2)]
        public int cr_term { get; set; }
        [Required]
        [Range(1,7)]
        public int cr_level { get; set; }
        public Faculty Faculty { get; set; }
        [Required]
        public int Facultyid { get; set; }
        public Instructor Instructor { get; set; }
        public int? Instructorid { get; set; }

        
    }
}