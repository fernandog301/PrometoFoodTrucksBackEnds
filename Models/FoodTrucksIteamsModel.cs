using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PrometoFoodTrucksBackEnds.Models
{
    public class FoodTrucksIteamsModel
    {
        
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
            public int ID { get; set; }
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
            public int itemId { get; set; }

            public string? itemName { get; set; }

            public double? itemPrice { get; set; }
        }
        

        



        public FoodTrucksIteamsModel(){}

    }
}