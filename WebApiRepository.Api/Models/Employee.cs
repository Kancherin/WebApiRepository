using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRepository.Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Dni { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Cargo { get; set; }
    }
}
    