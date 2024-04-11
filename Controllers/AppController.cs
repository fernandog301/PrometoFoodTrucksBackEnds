using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Services;

namespace PrometoFoodTrucksBackEnds.Controllers
{
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly AppServices _data;

        public AppController(AppServices data)
        {
            _data = data;
        }

        // Add bathroom
        [HttpPost]
        [Route("AddFoodTruckIteam")]
        public bool AddFoodTruckIteam(AppIteamModels newFoodTruckIteam)
        {
            return _data.AddFoodTruckIteam(newFoodTruckIteam);
        }

        // Get bathrooms
        [HttpGet]
        [Route("GetAllFoodTruckIteam")]
        public IEnumerable<AppIteamModels> GetAllFoodTruckIteam()
        {
            return _data.GetAllFoodTruckIteam();
        }

        // Update bathroom
        // Since we are updating a bathroom, we want to take in the entire BathroomModel and call it bathroomUpdate
        [HttpGet]
        [Route("UpdateFoodTruckIteam")]
        public bool UpdateFoodTruckIteam(AppIteamModels FoodTruckIteamUpdate)
        {
            return _data.UpdateFoodTruckIteam(FoodTruckIteamUpdate);
        }

        // Delete bathroom
        [HttpDelete]
        [Route("DeleteFoodTruckIteam")]
        public bool DeleteFoodTruckIteam(AppIteamModels FoodTruckIteamToDelete)
        {
            return _data.DeleteFoodTruckIteam(FoodTruckIteamToDelete);
        }
    }
}