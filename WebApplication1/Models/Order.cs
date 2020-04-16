using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Scaffolding.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Client")]
        public int IdClient { get; set; }
        public Client Client { get; set; }

        [DataType(DataType.Date)]
        public string Data { get; set; }
    }
}
