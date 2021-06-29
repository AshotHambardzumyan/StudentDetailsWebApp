using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Entities
{
    public class Course
    {
        [Required]
        [MaxLength(5)]
        [MinLength(1)]
        public string Name { get; set; }

        public Guid Id { get; set; }

        public bool Status { get; set; }

        public Faculty Faculty { get; set; }
    }
}
