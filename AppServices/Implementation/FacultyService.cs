using System;
using System.Linq;
using System.Text;
using App.Models.Data;
using App.Models.Entities;
using AppServices.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppServices.Implementation
{
    internal class FacultyService : IFacultyService
    {
        private readonly IUniversityDbContext _dbContext;
        public FacultyService(IUniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Faculty faculty)
        {
            _dbContext.Faculties.Add(faculty);
        }

        public Faculty Get(Guid? id)
        {
            var faculty = _dbContext.Faculties.FirstOrDefault(x => x.Id == id && x.Status);
            return faculty;
        }

        public List<Faculty> GetAll()
        {
            return _dbContext.Faculties.Where(x => x.Status).ToList();
        }

        public void Update(Faculty faculty)
        {
            var oldFaculty = Get(faculty.Id);

            int facultyIndex = _dbContext.Faculties.IndexOf(oldFaculty);

            _dbContext.Faculties[facultyIndex] = faculty;
        }
    }
}