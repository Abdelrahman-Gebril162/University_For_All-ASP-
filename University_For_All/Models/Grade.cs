using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace University_For_All.Models
{
    public class Grade
    {
        public int id { get; set; }
        
        public int points { get; set; }
        [Required]
        [StringLength(1)]
        public string Latter { get; set; }

    }
}