using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrometoFoodTrucksBackEnds.Models.DTO
{
    public class MenuDTO
    {

        public int FoodTrucksID { get; set;} 
        [Key]
        public int itemId { get; set; }
        public string? itemName { get; set; }
        public string? itemPrice { get; set; }

    }
}