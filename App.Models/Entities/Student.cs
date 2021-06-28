using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Entities
{
    public class Student
    {
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }

        public string SureName { get; set; }

        public int Age { get; set; }

        public Guid Id { get; set; }

        [Required]
        public Course Course { get; set; }

        public Faculty Faculty { get; set; }
    }
}
