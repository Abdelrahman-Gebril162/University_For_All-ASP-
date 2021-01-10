using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace University_For_All.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string st_fname { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string st_lname { get; set; }
        [Required]
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime st_DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string st_address { get; set; }
        [Required]
        [Display(Name = "City")]
        public string st_city { get; set; }
        [Required]
        [Display(Name = "Phone_Number")]
        [RegularExpression(@"^01[0-5]{1}[0-9]{8}$",ErrorMessage = "please add a valid (Egypt) phone Number")]
        public string st_phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w.+\-]+@gmail\.com$", ErrorMessage = "webSite Accept only(Gmail)")]
        public string st_email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string st_password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("st_password", ErrorMessage = "The password and confirmation password do not match.")]
        public string st_confirmPassword { get; set; }
        
        [Display(Name = "Upload Image")]
        public string st_picture { get; set; }
        [Required]
        [Display(Name = "Your Level")]
        [Range(1,7)]
        public int st_level { get; set; }
        [Required]
        [Display(Name = "Under Graduate ?")]
        
        public bool Undergrad { get; set; }
        public DateTime enroll_date { get; set; }
        public Faculty Faculty { get; set; }
        [Required]
        [Display(Name = "Your Faculty")]
        public int FacultyId { get; set; }
        public Department Department { get; set; }
        [Required]
        [Display(Name = "Your Department")]
        public int? DepartmentId { get; set; }
       
        
    }
}