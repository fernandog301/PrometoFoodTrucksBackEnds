using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PrometoFoodTrucksBackEnds.Models.DTO;

namespace PrometoFoodTrucksBackEnds.Models
{
    public class FoodTrucksIteamsModel
    {
        
            public int ID { get; set; }

            public int UserId { get; set;}
            public string? Address { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? ZipCode { get; set; }
            public double? Latitude { get; set; }
            public double? Longitude { get; set; }
            public string? Name { get; set; }

            public string? image { get; set; }

            public string? schedule { get; set; }

            public string? description { get; set; }

            public string? category { get; set; }

            public string? Rating { get; set; }
            public bool? IsDeleted { get; set; }

            public List<MenuItem>? menuItems { get; set; }

            public class MenuItem
    {
            public int FoodTrucksID { get; set;} 
            [Key]
            public int itemId { get; set; }
            public string? itemName { get; set; }

            public string? itemPrice { get; set; }
    }
        
        public FoodTrucksIteamsModel(){}

    }
}