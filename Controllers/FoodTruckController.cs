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




        [HttpGet]
        [Route("GetAllFoodTrucks")]
        public IEnumerable<FoodTrucksIteamsModel> GetAllFoodTrucks(int ID)
        {
            return _data.GetAllFoodTrucks(ID);
        }



        [HttpGet]
        [Route("GetFoodTruckById")]
        public FoodTrucksIteamsModel GetFoodTruckById(int id)
        {
            return _data.GetFoodTruckById(id);
        }


        [HttpPost]
        [Route("AddFoodTruck")]
        public bool AddFoodTruck(FoodTrucksIteamsModel newFoodTruck)
        {
            return _data.AddFoodTruck(newFoodTruck);
        }


        [HttpPut]
        [Route("UpdateFoodTrucksItems")]
        public bool UpdateFoodTrucksItems(FoodTrucksIteamsModel FoodTruckToUpdate)
        {
            return _data.UpdateFoodTrucksItems(FoodTruckToUpdate);
        }

        [HttpPut]
        [HttpPut("UpdateFoodTruck/{id}/{FoodTruckName}")]
        public bool UpdateFoodTrucks(int id, string FoodTruckName)
        {
            return _data.UpdateFoodTrucks(id, FoodTruckName);
        }


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