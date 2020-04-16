using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffolding.Models
{
    public class Creator
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int IdCountry { get; set; }
        public Country Country { get; set; }
    }
}
