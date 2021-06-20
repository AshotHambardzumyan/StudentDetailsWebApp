using System;
using System.Linq;
using System.Text;
using App.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface ICourseService
    {
        void Add(Course course);

        void Update(Course course);

        Course Get(Guid id);

        List<Course> GetAll();
    }
}
