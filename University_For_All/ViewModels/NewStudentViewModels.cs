using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using University_For_All.Models;

namespace University_For_All.ViewModels
{
    public class StudentNewStudentViewModels
    {
        
        public Student Student { get; set; }
        
        public List<Faculty> Faculties { get; set; }
        
        public List<Department> Departments { get; set; }

        public int FacultyId { get; set; }
        public int  DepartmentId { get; set; }
    }
}