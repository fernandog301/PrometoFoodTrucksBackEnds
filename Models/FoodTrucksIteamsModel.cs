using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrometoFoodTrucksBackEnds.Models
{
    public class FoodTrucksIteamsModel
    {
        public int ID { get; set; }
        
        public string? FoodTruckName { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string? FoodTruckCategory { get; set; }

        public string? ImageUrl { get; set;} 

        public string? Description { get; set;}

        public string? Email { get; set;}

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zipcode { get; set; }

        public string? FoodTruckPrices { get; set; }

        public string? FoodTruckMenu { get; set; }

        public string? FoodTruckHours { get; set; }

        public string? FoodTruckDays { get; set;}

        public string? FoodTruckReviews { get; set;}

        public bool? IsThere { get; set; } = false;

        public bool? IsDeleted { get; set; } = false;

        public FoodTrucksIteamsModel(){}

    }
}