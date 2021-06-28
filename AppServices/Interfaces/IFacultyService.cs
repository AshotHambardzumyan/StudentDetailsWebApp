using System;
using System.Linq;
using System.Text;
using App.Models.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AppServices.Interfaces
{
    public interface IFacultyService
    {
        void Add(Faculty faculty);

        void Update(Faculty faculty);

        Faculty Get(Guid? id);

        List<Faculty> GetAll();
    }
}
