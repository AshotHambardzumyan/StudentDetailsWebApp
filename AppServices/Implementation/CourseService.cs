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
    internal class CourseService : ICourseService
    {
        private readonly IUniversityDbContext _dbContext;
        public CourseService(IUniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Course course)
        {
            _dbContext.Courses.Add(course);
        }

        public Course Get(Guid id)
        {
            return _dbContext.Courses.FirstOrDefault(x => x.Id == id && x.Status);
        }

        public List<Course> GetAll()
        {
            return _dbContext.Courses.Where(x => x.Status).ToList();
        }

        public void Update(Course course)
        {
            var oldCourse = Get(course.Id);

            int courseIndex = _dbContext.Courses.IndexOf(oldCourse);

            _dbContext.Courses[courseIndex] = course;
        }
    }
}
