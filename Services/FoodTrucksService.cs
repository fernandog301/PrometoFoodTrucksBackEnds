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

        public bool AddFoodTruck(FoodTrucksIteamsModel newFoodTruck)
        {
            _context.Add(newFoodTruck);
            // Any return other than zero, we save changes. This is because this function is set up as a bool
            return _context.SaveChanges() != 0;
        }

        // Start
        

        public bool AddMenu(MenuItem menuToAdd)
        {
            var truck = _context.TruckInfos.FirstOrDefault(t => t.ID == menuToAdd.itemId);
            if (truck != null)
            {
                MenuItem menuItem = new MenuItem
                {
                    // itemId = menuToAdd.TruckId,
                    itemName = menuToAdd.itemName,
                    itemPrice = Convert.ToString(menuToAdd.itemPrice) // Convert string to decimal
                };
                _context.MenuItems.Add(menuItem);
                return _context.SaveChanges() != 0;
            }
            return false; // If truck with given id doesn't exist
        }

        public bool DeleteMenuItem(int itemId)
        {
            var menuItemToDelete = _context.MenuItems.FirstOrDefault(m => m.itemId == itemId);
            if (menuItemToDelete != null)
            {
                _context.MenuItems.Remove(menuItemToDelete);
                return _context.SaveChanges() != 0;
            }
            return false; // If menu item with given id doesn't exist
        }

        public bool UpdateMenuItem(MenuItem menuItems)
        {
            _context.MenuItems.Update(menuItems);
            return _context.SaveChanges() != 0;
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


        public bool UpdateFoodTruck(FoodTrucksIteamsModel FoodTruckUpdate)
        {
            _context.Update<FoodTrucksIteamsModel>(FoodTruckUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteFoodTruck(FoodTrucksIteamsModel FoodTruckToDelete)
        {
            FoodTruckToDelete.IsDeleted = true;
            _context.Update<FoodTrucksIteamsModel>(FoodTruckToDelete);
            return _context.SaveChanges() != 0;
        }
    
        public UserModel GetUserByUsername(string username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

    }
}