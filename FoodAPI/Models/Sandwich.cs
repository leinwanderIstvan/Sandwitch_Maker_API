using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Models
{
    public class Sandwich
    {
        [Key]
        public int ID { get; set; }
        public int Price { get; set; }
        [Required]
        public string SandwichName { get; set; }
        
    }
}
