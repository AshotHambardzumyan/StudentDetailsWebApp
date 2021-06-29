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

            var course = _dbContext.Courses.FirstOrDefault(x => x.Id == student.Course.Id);

            student.Course = course;
            var faculty = _dbContext.Faculties.FirstOrDefault(x => x.Id == student.Faculty.Id);

            student.Faculty = faculty;

            _dbContext.Students[courseIndex] = student;
        }

        public void Delete(Guid id)
        {
            _dbContext.Students.Remove(Get(id));
        }

        public List<Student> GetSameStudents(Guid id)
        {
            List<Student> SameStudents = new List<Student>();

            Student student = Get(id);

            foreach (var item in GetAll())
            {
                if ((item.Course == student.Course) && (item.Faculty == student.Faculty))
                {
                    SameStudents.Add(item);
                }
            }
            return SameStudents;
        }
    }
}