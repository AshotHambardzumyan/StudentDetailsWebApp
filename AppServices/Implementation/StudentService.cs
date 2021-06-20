using System;
using System.Linq;
using System.Text;
using App.Models.Data;
using App.Models.Entities;
using System.Threading.Tasks;
using AppServices.Interfaces;
using System.Collections.Generic;

namespace AppServices.Implementation
{
    internal class StudentService : IStudentService
    {
        private readonly IUniversityDbContext _dbContext;
        public StudentService(IUniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Student student)
        {
            _dbContext.Students.Add(student);
        }

        public Student Get(Guid id)
        {
            return _dbContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public List<Student> GetAll()
        {
            return _dbContext.Students;
        }

        public void Update(Student student)
        {
            var oldStudent = Get(student.Id);

            int courseIndex = _dbContext.Students.IndexOf(oldStudent);

            var c = _dbContext.Courses.Where(x => x.Id == student.Courses.Id);

            student.Courses = c.FirstOrDefault();

            _dbContext.Students[courseIndex] = student;
        }

        public void Delete(Guid id)
        {
            _dbContext.Students.Remove(Get(id));
        }
    }
}