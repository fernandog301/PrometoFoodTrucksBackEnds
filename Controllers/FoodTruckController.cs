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

        // Add Food Truck
        [HttpPost]
        [Route("AddFoodTruckItems")]
        public bool AddFoodTruckItems(FoodTrucksIteamsModel foodTruckItems)
        {
            return _data.AddFoodTruckItems(foodTruckItems);
        }

        [HttpGet]
        [Route("GetAllFoodTrucks")]
        public IEnumerable<FoodTrucksIteamsModel> GetAllFoodTrucks()
        {
            return _data.GetAllFoodTrucks();
        }

        [HttpGet]
        [Route("GetAllFoodTruckItems")]
        public List<FoodTrucksIteamsModel>GetAllFoodTruckItems()
        {
            return _data.GetAllFoodTruckItems();
        }


        [HttpPost]
        [Route("CreateFoodTruckForUser")]
        public void CreateFoodTruckForUser(int userId, FoodTrucksIteamsModel foodTrucks)
        {
            _data.CreateFoodTruckForUser(userId, foodTrucks);

        }


        // Get Food Trucks as GeoJSON data
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

        // Update Food Truck
        [HttpPut]
        [Route("UpdateFoodTruckForUser")]
        public void UpdateFoodTruckForUser(int userId, FoodTrucksIteamsModel FoodTruckUpdate)
        {
            _data.UpdateFoodTruckForUser(userId, FoodTruckUpdate);
        }

        // Delete Food Truck
        [HttpDelete]
        [Route("DeleteFoodTruckForUser")]
        public void DeleteFoodTruckForUser(int userId)
        {
            _data.DeleteFoodTruckForUser(userId);
        }



        [HttpGet]
        [Route("GetUserByUsername")]
        public UserModel GetUserByUsername(string username)
        {
            return _data.GetUserByUsername(username);
        }

        [HttpPost]
        [Route("AddMenuForFoodTruck")]
        public void AddMenuForFoodTruck(int userId, MenuItem menuToAdd)
        {
            _data.AddMenuForFoodTruck(userId, menuToAdd);
        }

        [HttpDelete]
        [Route("DeleteMenuItem")]
        public void DeleteMenuItem(int userId, int menuItemId)
        {
            _data.DeleteMenuItem(userId,menuItemId);
        }

        [HttpPut]
        [Route("UpdateMenuItem")]
        public void UpdateMenuItem(int userId, string newItemName, string newItemPrice,  MenuItem updateMenuItem)
        {
            _data.UpdateMenuItem(userId, newItemName, newItemPrice, updateMenuItem);
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