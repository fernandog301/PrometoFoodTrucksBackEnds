using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrometoFoodTrucksBackEnds.Models.DTO
{
    public class MenuDTO
    {
        [Key]
        // public int TruckId { get; set; }
        public int itemId { get; set; }

         // Foreign key to link to FoodTrucks table

        public string? itemName { get; set; }

        public string? itemPrice { get; set; }
        // public ICollection<MenuItem> MenuItems { get; set; }


    }
}