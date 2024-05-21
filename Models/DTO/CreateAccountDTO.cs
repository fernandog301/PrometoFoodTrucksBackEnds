using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrometoFoodTrucksBackEnds.Models.DTO
{
    public class CreateAccountDTO
    {
            public int ID { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string? Address { get; set; }
            
            public string? City { get; set; }
            
            public string? State { get; set; }
            
            public string? ZipCode { get; set; }
            
            public double? Latitude { get; set; }
            
            public double? Longitude { get; set; }
            
            public string? Name { get; set; }

            public string? Image { get; set; }

            public string? Schedule { get; set; }

            public string? Description { get; set; }

            public string? Category { get; set; }

            public string? Rating { get; set; }
            
            public bool? IsDeleted { get; set; }

            public string? itemName { get; set; }

            public string? itemPrice { get; set; }
            
            
    }
}