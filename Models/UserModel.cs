using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrometoFoodTrucksBackEnds.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        public string? Username { get; set; }

        public string? Salt { get; set; }
        public string? Hash { get; set; }
        
       public FoodTrucksIteamsModel FoodTrucksItems{ get; set; }
        public UserModel(){
            
        }

    }
}