using System;
using System.Linq;
using System.Text;
using App.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace App.Models.Data
{
    internal class UniversityDbContext : IUniversityDbContext
    {
        public List<Course> Courses { get; set; }
        public List<Faculty> Faculties { get; set; }
        public List<Student> Students { get; set; }

        public UniversityDbContext()
        {
            Courses = new List<Course>();

            Faculties = new List<Faculty>();

            Students = new List<Student>();
        }
    }
    public interface IUniversityDbContext
    {
        public List<Course> Courses { get; set; }

        public List<Faculty> Faculties { get; set; }

        public List<Student> Students { get; set; }
    }
}