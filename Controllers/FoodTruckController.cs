using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Models.DTO;
using PrometoFoodTrucksBackEnds.Services;
using static PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel;

namespace PrometoFoodTrucksBackEnds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodTruckController : ControllerBase
    {
        private readonly FoodTrucksService _data;
        public FoodTruckController(FoodTrucksService data)
        {
            _data = data;
        }




        // [HttpGet]
        // [Route("GetTruckInfo")]
        // public UserModel GetTruckInfo(int truckId)
        // {
        //     return _data.GetTruckInfo(truckId);
        // }

        // Add bathroom
        [HttpPost]
        [Route("AddFoodTruck")]
        public bool AddFoodTruck(FoodTrucksIteamsModel newFoodTruck)
        {
            return _data.AddFoodTruck(newFoodTruck);
        }

        [HttpGet]
        [Route("GetAllFoodTrucks")]
        public IEnumerable<FoodTrucksIteamsModel> GetAllFoodTrucks()
        {
            return _data.GetAllFoodTrucks();
        }

        // Get bathrooms as GeoJSON data
        [HttpGet]
        [Route("GetAllFoodTrucksAsGeoJSON")]
        public ActionResult<string> GetAllFoodTrucksAsGeoJSON()
        {
            // Retrieve GeoJSON data from the service
            string geoJSON = _data.GetAllFoodTrucksAsGeoJSON();

            // Check if data was found
            if (string.IsNullOrEmpty(geoJSON))
            {
                return NotFound(); // Return 404 if no data found
            }

            return Ok(geoJSON);
        }

        // Update bathroom
        // Since we are updating a bathroom, we want to take in the entire BathroomModel and call it bathroomUpdate
        [HttpPut]
        [Route("UpdateFoodTruck")]
        public bool UpdateFoodTruck(FoodTrucksIteamsModel FoodTruckUpdate)
        {
            return _data.UpdateFoodTruck(FoodTruckUpdate);
        }

        // Delete bathroom
        [HttpDelete]
        [Route("DeleteFoodTruck")]
        public bool DeleteFoodTruck(FoodTrucksIteamsModel FoodTruckToDelete)
        {
            return _data.DeleteFoodTruck(FoodTruckToDelete);
        }



        [HttpGet]
        [Route("GetUserByUsername")]
        public UserModel GetUserByUsername(string username)
        {
            return _data.GetUserByUsername(username);
        }

        [HttpPost]
        [Route("AddMenu")]
        public bool AddMenu(MenuItem menuToAdd)
        {
            return _data.AddMenu(menuToAdd);
        }

        [HttpDelete]
        [Route("DeleteMenuItem")]
        public bool DeleteMenuItem(int itemId)
        {
            return _data.DeleteMenuItem(itemId);
        }

        [HttpPut]
        [Route("UpdateMenuItem")]
        public bool UpdateMenuItem(MenuItem menuItems)
        {
            return _data.UpdateMenuItem(menuItems);
        }


        // [HttpGet]
        // [Route("GetFoodTruckById")]
        // public async FoodTrucksIteamsModel GetFoodTruckById(int id)
        // {
        //     return await _data.GetFoodTruckById(id);
        // }


        // [HttpPost]
        // [Route("AddFoodTruck")]
        // public bool AddTruckAsync(FoodTrucksIteamsModel truck)
        // {
        //     return _data.AddTruckAsync(truck);
        // }


        // [HttpPut]
        // [Route("UpdateFoodTrucksItems")]
        // public bool UpdateFoodTrucksItems(FoodTrucksIteamsModel FoodTruckToUpdate)
        // {
        //     return _data.UpdateFoodTrucksItems(FoodTruckToUpdate);
        // }

        // [HttpPut]
        // [HttpPut("UpdateFoodTruck/{id}/{FoodTruckName}")]
        // public bool UpdateFoodTrucks(int id, string FoodTruckName)
        // {
        //     return _data.UpdateFoodTrucks(id, FoodTruckName);
        // }


        // [HttpGet]
        // [Route("GetFoodTruckHours/{FoodTruckHours}/{IsDeleted}")]
        // public bool GetFoodTruckHours(FoodTrucksIteamsModel IsDeleted)
        // {
        //     return _data.GetFoodTruckHours(IsDeleted);
        // }

        // [HttpPost]
        // [Route("CreateNewFoodTruck")]
        // public bool CreateNewFoodTruck(FoodTrucksIteamsModel newFoodTruck)
        // {
        //     return _data.CreateNewFoodTruck(newFoodTruck);
        // }

        



    }
}