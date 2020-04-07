using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodAPI.Models.Dtos
{
    public class SandwichDto
    {
       
        public int ID { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string SandwichName { get; set; }
        [Required]
        public string Ingredient { get; set; }
        [Required]
        public string Allergen { get; set; }
    }
}
