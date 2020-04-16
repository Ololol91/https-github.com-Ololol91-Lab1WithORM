using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scaffolding.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Mobile_Number { get; set; }

        [ForeignKey("Post")]
        public int IdPost { get; set; }
        public Post Post { get; set; }
    }
}
