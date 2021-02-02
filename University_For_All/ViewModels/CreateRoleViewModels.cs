using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace University_For_All.ViewModels
{
    public class CreateRoleViewModels
    {
        [Required]
        public string RoleName { get; set; }
    }
}