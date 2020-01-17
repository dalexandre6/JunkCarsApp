using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JunkCarsApp.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string Make { get; set; }
        public string City { get; set; }
        public int Price { get; set; }
    }
}
