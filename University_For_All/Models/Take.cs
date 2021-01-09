using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace University_For_All.Models
{
    public class Take
    {
        public int id { get; set; }
        public Student Student { get; set; }
        public int Studentid { get; set; }
        public Course Course { get; set; }
        public int Courseid { get; set; }
        public Grade Grade { get; set; }
        public int Gradeid { get; set; }
        
    }
}