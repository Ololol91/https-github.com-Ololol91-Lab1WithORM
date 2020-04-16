using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scaffolding.Models
{
    public class Sending
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int IdProduct { get; set; }
        public Product Product { get; set; }

        [ForeignKey("Order")]
        public int IdOrder { get; set; }
        public Order Order { get; set; }

        [ForeignKey("Provider")]
        public int IdProvider { get; set; }
        public Provider Provider { get; set; }

        [ForeignKey("Employee")]
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; }

        [DataType(DataType.Date)]
        public string DateDelivery { get; set; }
        [DataType(DataType.Date)]
        public string DateDeparture { get; set; }
    }
}
