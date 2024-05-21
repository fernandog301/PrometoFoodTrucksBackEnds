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
using static PrometoFoodTrucksBackEnds.Models.DTO.CreateAccountDTO;

namespace PrometoFoodTrucksBackEnds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserServices _data;

        public UserController(UserServices data)
        {
            // we want to pass data into _data so we can use it outside of our constructor
            _data = data;
        }


        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        // [HttpPut]
        // [Route("FoodTrucksWithUser")]
        // public void FoodTrucksWithUser(int userId, int FoodTrucksID)
        // {
        //     _data.FoodTrucksWithUser(userId, FoodTrucksID);
        // }

        // [HttpDelete]
        // [Route("RemoveFoodTruckFromUser")]
        // public void RemoveFoodTruckFromUser(int userId)
        // {
        //     _data.RemoveFoodTruckFromUser(userId);

        // }

        //AddUser endpoint
        //if user already exists (check this)
        //if user does not exist, create new account
        //else return false
        //we will set this up as a bool

        [HttpPost]
        [Route("AddUser")]

        // UserToAdd is a variable we created
        public bool AddUser(CreateAccountDTO userToAdd)
        {
            return _data.AddUser(userToAdd);
        }


        //UpdateUser endpoint
        [HttpPut]
        [Route("UpdateUser")]

        public bool UpdateUser(UserModel userToUpdate)
        {
            return _data.UpdateUser(userToUpdate);
        }

        [HttpPut]
        [Route("UpdateUser/{id}/{username}")]

        public bool UpdateUser(int id, string username)
        {
            return _data.UpdateUsername(id, username);
        }

        [HttpGet]
        [Route("GetUserIdDTOByUsername/{username}")]
        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            return _data.GetUserIdDTOByUsername(username);
        }

        //DeleteUser endpoint
        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]

        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

        [HttpGet]
        [Route("GetAllFoodTrucks")]
        public IEnumerable<UserModel> GetAllFoodTrucks()
        {
            return _data.GetAllFoodTrucks();
        }



        // Get User By Username endpoint
        [HttpGet]
        [Route("GetUserByUsername/{username}")]
        public UserIdDTO GetUserByUsername(string username)
        {
            return _data.GetUserIdDTOByUsername(username);
        }
        
        [HttpGet]
        [Route("GetAllFoodTrucksAsGeoJSON")]
        public string GetAllFoodTrucksAsGeoJSON()
        {
            return _data.GetAllFoodTrucksAsGeoJSON();
        }


        [HttpPost]
        [Route("AddFoodTruck")]
        public bool AddFoodTruck(UserModel userWithFoodTruck)
        {
            return _data.AddFoodTruck(userWithFoodTruck);
        }

        [HttpPut]
        [Route("UpdateFoodTruck")]
        public bool UpdateFoodTruck(UserModel userWithUpdatedFoodTruck)
        {
            return _data.UpdateFoodTruck(userWithUpdatedFoodTruck);
        }

        [HttpDelete]
        [Route("DeleteFoodTruck")]

        public bool DeleteFoodTruck(int userId)
        {
            return _data.DeleteFoodTruck(userId);
        }

        // [HttpPost]
        // [Route("AddMenuForFoodTruck")]
        // public void AddMenuForFoodTruck(int userId, UserModel.MenuItem menuToAdd)
        // {
        //     _data.AddMenuForFoodTruck(userId, menuToAdd);
        // }


        // [HttpDelete]
        // [Route("DeleteUser")]
        // public void DeleteMenuItem(int userId, int menuItemId)
        // {
        //     _data.DeleteMenuItem(userId, menuItemId);
        // }

        // [HttpPut]
        // [Route("UpdateMenuItem")]
        // public void UpdateMenuItem(int userId, UserModel.MenuItem updateMenuItem)
        // {
        //     _data.UpdateMenuItem(userId,updateMenuItem);
        // }


    }
}