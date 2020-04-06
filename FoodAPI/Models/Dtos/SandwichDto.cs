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
        public int Price { get; set; }
        
        public string SandwichName { get; set; }
        
        public string Ingredient { get; set; }
        
        public string Allergen { get; set; }
    }
}
