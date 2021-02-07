using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Instructor
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string ints_fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string inst_lname { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w.+\-]+@gmail\.com$", ErrorMessage = "webSite Accept only(Gmail)")]
        public string ints_email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string inst_password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("inst_password", ErrorMessage = "The password and confirmation password do not match.")]
        public string inst_confirmPassword { get; set; }
        public string inst_picture { get; set; }

        public Rank Rank { get; set; }
        [Required]
        public int Rankid { get; set; }
        public Faculty Faculty { get; set; }
        [Required]
        public int  Facultyid { get; set; }
    }
}