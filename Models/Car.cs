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
        [Required]
        [MaxLength(15)]
        [StringLength(20,MinimumLength =2)]
        public string Make { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 2)]
        public string City { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Range(0,1200)]
        [Display(Name ="Price in US Dollars: ")]
        public int Price { get; set; }
    }
}
