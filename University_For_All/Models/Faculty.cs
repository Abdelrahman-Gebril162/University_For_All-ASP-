using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Faculty
    {
        public int id { get; set; }
        [Display(Name = "Faculty Name")]
        [Required]
        public string fc_name { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string fc_description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created at")]
        public DateTime fc_created_at { get; set; }
        [Required]
        [Range(1,7)]
        [Display(Name = "Number Of Levels")]

        public int fc_levels_num { get; set; }
        [Range(1,3)]
        [Required]
        [Display(Name = "Special Year")]

        public int fc_spicial_year { get; set; }
        public string fc_logo { get; set; }
    }
}