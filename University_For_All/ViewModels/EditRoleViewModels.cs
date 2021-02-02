using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace University_For_All.ViewModels
{
    public class EditRoleViewModels
    {
        public EditRoleViewModels()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required]
        public string  RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}