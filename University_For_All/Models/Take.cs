using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Take
    {
        public int id { get; set; }
        public Student Student { get; set; }
        [Required]
        [Display(Name = "Select Student")]
        [Index("studentAndCourse",1,IsUnique = true)]
        public int Studentid { get; set; }
        public Course Course { get; set; }
        [Required]
        [Display(Name = "Select Course")]
        [Index("studentAndCourse",2,IsUnique = true)]
        
        public int Courseid { get; set; }
        public Grade Grade { get; set; }
        [Display(Name = "Select Grade")]

        public int? Gradeid { get; set; }
        
    }
}