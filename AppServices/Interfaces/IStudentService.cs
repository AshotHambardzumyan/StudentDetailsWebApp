using System;
using System.Linq;
using System.Text;
using App.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IStudentService
    {
        void Add(Student student);

        void Update(Student student);

        Student Get(Guid id);

        List<Student> GetAll();

        void Delete(Guid id);
    }
}
