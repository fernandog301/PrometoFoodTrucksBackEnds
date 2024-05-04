using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrometoFoodTrucksBackEnds.Models.DTO
{
    public class MenuDTO
    {
        public int TruckId { get; set; } // Foreign key to link to FoodTrucks table
        public int? itemId { get; set; }

        public string? itemName { get; set; }

        public string? itemPrice { get; set; }

    }
}