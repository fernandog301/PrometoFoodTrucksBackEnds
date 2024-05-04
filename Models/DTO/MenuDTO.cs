using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrometoFoodTrucksBackEnds.Models.DTO
{
    public class MenuDTO
    {
        public int? itemId { get; set; }

        public string? itemName { get; set; }

        public double? itemPrice { get; set; }

    }
}