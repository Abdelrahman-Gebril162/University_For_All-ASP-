using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class ContactUs
    {
        [Required]
        [RegularExpression(@"^[\w.+\-]+@gmail\.com$", ErrorMessage = "webSite Accept only(Gmail)")]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}