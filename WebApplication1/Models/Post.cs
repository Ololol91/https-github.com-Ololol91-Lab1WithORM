using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Scaffolding.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Salary { get; set; }
        public string Responsibility { get; set; }

    }
}
