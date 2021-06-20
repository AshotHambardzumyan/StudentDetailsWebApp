using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Entities
{
    public class Faculty
    {
        [MaxLength(50)]
        [MinLength(3)]
        public string Name { get; set; }
        public Guid Id { get; set; }
        public bool Status { get; set; }
    }
}