using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Department
    {
        public int id { get; set; }
        [Display(Name = "Department Name")]
        [Required]
        public string name { get; set; }
        [Required]
        public string description { get; set; }
        public Faculty Faculty { get; set; }
        [Required(ErrorMessage = "Faculty is Required")]
        public int Facultyid { get; set; }
    }
}