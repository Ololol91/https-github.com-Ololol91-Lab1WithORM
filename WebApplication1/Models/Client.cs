using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scaffolding.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Mobile_Number { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
