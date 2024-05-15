using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrometoFoodTrucksBackEnds.Controllers;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Models.DTO;
using PrometoFoodTrucksBackEnds.Services.Context;
using static PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel;

namespace PrometoFoodTrucksBackEnds.Services
{
    public class FoodTrucksService : ControllerBase
    {
        
        private readonly DataContext _context;
        public FoodTrucksService(DataContext context){
            _context = context;
        }


    // End

        public IEnumerable<FoodTrucksIteamsModel> GetAllFoodTrucks()
        {
            
            return _context.TruckInfos;
        }

        public string GetAllFoodTrucksAsGeoJSON()
        {
            // Your SQL query to generate GeoJSON data
            string sqlQuery = @"
                DECLARE @featureList nvarchar(max) =
                (
                    SELECT
                    'Feature'                                           as 'type',
                    address                                             as 'properties.address',
                    city                                                as 'properties.city',
                    state                                               as 'properties.state',
                    zipCode                                             as 'properties.zipCode',
                    name                                                as 'properties.name',
                    image                                               as 'properties.image',
                    schedule                                            as 'properties.schedule',
                    description                                         as 'properties.description',
                    category                                            as 'properties.category',
                    IsDeleted                                           as 'properties.IsDeleted',
                    
                    'Point'                                             as 'geometry.type',
                    JSON_QUERY(CONCAT('[', CAST(longitude AS decimal(18, 15)), ', ', CAST(latitude AS decimal(18, 15)), ']')) as 'geometry.coordinates'                
                    FROM TruckInfos
                FOR JSON PATH
            )
            

                DECLARE @featureCollection nvarchar(max) = (
                    SELECT 'FeatureCollection' as 'type',
                    JSON_QUERY(@featureList)   as 'features'
                    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER
                )

                SELECT @featureCollection";

            using (SqlConnection connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                SqlCommand command = new SqlCommand(sqlQuery, connection);
                connection.Open();

                string geoJSON = (string)command.ExecuteScalar();

                return geoJSON;
            }
        }

        public List<FoodTrucksIteamsModel>GetAllFoodTruckItems()
        {
            return _context.TruckInfos.ToList();
        }

        public void CreateFoodTruckForUser(int userId, FoodTrucksIteamsModel foodTrucks)
        {
            var user = _context.UserInfo.FirstOrDefault(u => u.UserID == userId);
            if (user != null)
            {
                    foodTrucks.UserId = userId;
                    _context.TruckInfos.Add(foodTrucks);
                    _context.SaveChanges();
            }
        }

        public bool AddFoodTruckItems(FoodTrucksIteamsModel foodTruckItems)
        {
            _context.TruckInfos.Add(foodTruckItems);
            return _context.SaveChanges() != 0;
        }

        public void UpdateFoodTruckForUser(int userId, FoodTrucksIteamsModel FoodTruckUpdate)
        {
            var exisitingIteam = _context.TruckInfos.FirstOrDefault(ft => ft.UserId == userId);
            if (exisitingIteam != null)
            {
                exisitingIteam.Name = FoodTruckUpdate.Name;
                exisitingIteam.image = FoodTruckUpdate.image;
                exisitingIteam.schedule = FoodTruckUpdate.schedule;
                exisitingIteam.description = FoodTruckUpdate.description;
                exisitingIteam.category = FoodTruckUpdate.category;
                exisitingIteam.Rating = FoodTruckUpdate.Rating;
                exisitingIteam.Address = FoodTruckUpdate.Address;
                exisitingIteam.State = FoodTruckUpdate.State;
                exisitingIteam.ZipCode = FoodTruckUpdate.ZipCode;
                exisitingIteam.Latitude = FoodTruckUpdate.Latitude;
                exisitingIteam.Longitude = FoodTruckUpdate.Longitude;
                _context.SaveChanges();
            }
        }



        public void DeleteFoodTruckForUser(int userId)
        {
            var itemsToDelete = _context.TruckInfos.FirstOrDefault(ft => ft.UserId == userId);

            if (itemsToDelete != null)
            {
                _context.TruckInfos.Remove(itemsToDelete);
                _context.SaveChanges();    
            
                }
        }

        public UserModel GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }
        


        public void AddMenuForFoodTruck(int userId, MenuItem menuToAdd)
        {
            var truck = _context.TruckInfos.FirstOrDefault(t => t.UserId == userId);

            if (truck != null)
            {
                menuToAdd.FoodTrucksID = truck.ID;
                // MenuItem menuItem = new MenuItem
                // {
                //     // itemId = menuToAdd.TruckId,
                //     itemName = menuToAdd.itemName,
                //     itemPrice = Convert.ToString(menuToAdd.itemPrice) // Convert string to decimal
                // };
                _context.MenuItems.Add(menuToAdd);
                _context.SaveChanges();
            }
            // return false; // If truck with given id doesn't exist
        }

        public void DeleteMenuItem(int userId, int menuItemId)
        {
            var existingFoodTruck = _context.TruckInfos.FirstOrDefault(t => t.UserId == userId);
            var menuItemToDelete = _context.MenuItems.FirstOrDefault(mi => mi.FoodTrucksID == existingFoodTruck.ID && mi.itemId == menuItemId);

            if (existingFoodTruck != null)
            {
                _context.MenuItems.Remove(menuItemToDelete);
                _context.SaveChanges();
            }
            // return false; // If menu item with given id doesn't exist
        }

        public void UpdateMenuItem(int userId, string newItemName, string newItemPrice,  MenuItem updateMenuItem)
        {
            var existingFoodTruck = _context.TruckInfos.FirstOrDefault(t => t.UserId == userId);
            var menuItemToUpdate = _context.MenuItems.FirstOrDefault(mi => mi.FoodTrucksID == existingFoodTruck.ID && mi.itemId == updateMenuItem.itemId);
            
            if (existingFoodTruck != null && menuItemToUpdate != null)
            {
                menuItemToUpdate.itemName = newItemName;

                menuItemToUpdate.itemPrice = newItemPrice;
                _context.SaveChanges();
            } 
        }

    }
}