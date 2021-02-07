using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using University_For_All.Models;

namespace University_For_All.ViewModels
{
    public class NewStaffViewModels
    {
        public Instructor Instructor { get; set; }
        public List<Rank> Ranks { get; set; }
        public List<Faculty> Faculties { get; set; }
        public int RankId { get; set; }
        public int FacultyId { get; set; }  
    }
}