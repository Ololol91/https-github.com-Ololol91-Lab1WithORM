using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scaffolding.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("TypeProduct")]
        public int IdTypeProduct { get; set; }
        public TypeProduct TypeProduct { get; set; }

        [ForeignKey("Creator")]
        public int IdCreator { get; set; }
        public Creator Creator { get; set; }
    }
}
