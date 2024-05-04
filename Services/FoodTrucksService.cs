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
                    (
                        SELECT
                            itemId                                      as 'itemId',
                            itemName                                    as 'itemName',
                            itemPrice                                   as 'itemPrice'
                        FROM MenuItems AS menu
                        WHERE menu.truckId = foodTruck.truckId
                        FOR JSON PATH
                    )                                                   as 'properties.menuItems',
                    'Point'                                             as 'geometry.type',
                    JSON_QUERY(CONCAT('[', CAST(longitude AS decimal(18, 15)), ', ', CAST(latitude AS decimal(18, 15)), ']')) as 'geometry.coordinates'                FROM FoodTrucks AS foodTruck
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

        // public bool GetTruckInfo(string name)
        // {
        //     return _context.Properties.SingleOrDefault(user => user.name == name) != null;
        // }


        // public MenuItem GetFoodItems(int Id)
        // {
        //     return _context.MenuItem.SingleOrDefault(IdItem => IdItem.itemId == Id);
        // }

        // public bool AddMenu(MenuDTO AddIteams) 
        // {
        //     bool result = false;
        //     UserModel foundUser = GetUserByUsername(AddIteams.itemId);


        //     if(!GetTruckInfo(AddIteams.name))
        //     {
        //         FoodTrucksIteamsModel foodTrucksModel = new FoodTrucksIteamsModel();

        //     }
        // }

        // public bool AddMenuItems(MenuDTO menuToAdd)
        // {
        //     bool result = false;
        //     if(!GetTruckInfo(menuToAdd.name))
        //     {

        //     }
        // }

        // public MenuDTO GetMenuItemsAsync(int itemId)
        // {
        //     MenuDTO MenuInfo = new MenuDTO();

        //     MenuItem foundUser = _context.MenuItem.SingleOrDefault(user => user.itemId == itemId);

        //     MenuInfo.itemId = foundUser.itemId;
        //     return MenuInfo;
        // }

        // public async Task<IEnumerable<FoodTrucksIteamsModel>> GetAllTrucksAsync()
        // {
        //     return await _context.TruckInfos.ToListAsync();
        // }

        // public bool AddTruckItems(Properties truckItemsToAdd)
        // {
        //     bool falseId = true;

        //     if(!GetTruckInfo(truckItemsToAdd.truckId))
        //     {

        //     }
        //     UserModel FoundUser = GetTruckInfo(truck.name);


        //     _context.TruckInfos.Add(truck);
        //     return _context.SaveChanges() !=0;
        // }

        // public async Task<bool> UpdateTruckAsync(Properties updatedFoodTruck)
        // {
        //     _context.Update<Properties>(updatedFoodTruck);
        //     return _context.SaveChanges() !=0;
        // }

        // public bool DeleteTruckAsync(int truckId)
        // {
        //     var truckToDelete = GetTruckInfo(truckId);
        //     if (truckToDelete != null)
        //     {
        //         _context.TruckInfos.Remove(truckToDelete);
        //         return _context.SaveChanges() !=0;
        //     }
        //     else
        //     {
        //         throw new InvalidOperationException("Truck not found.");
        //     }
        // }

    
        // public bool AddMenuItemAsync(int truckId, MenuItem menuItem)
        // {
        //     var truck = await _context.TruckInfos.GetTruckInfo(truckId);
        //     if (truck != null)
        //     {
        //         truck.MenuItem.Add(menuItem);
        //         return _context.SaveChanges() != 0;
        //     }
        //     else
        //     {
        //         throw new InvalidOperationException("Truck not found.");
        //     }
        // }

        // public async Task UpdateMenuItemAsync(int truckId, int itemId, MenuItem menuItem)
        // {
        //     var truck = await _context.TruckInfos.GetTruckInfo(truckId);
        //     if (truck != null)
        //     {
        //         var existingMenuItem = truck.MenuItems.FirstOrDefault(item => item.ItemId == itemId);
        //         if (existingMenuItem != null)
        //         {
        //             existingMenuItem.Name = menuItem.itemName;
        //             existingMenuItem.Price = menuItem.itemPrice;
        //             // Update other properties as needed
        //             await _context.SaveChangesAsync();
        //         }
        //         else
        //         {
        //             throw new InvalidOperationException("Menu item not found.");
        //         }
        //     }
        //     else
        //     {
        //         throw new InvalidOperationException("Truck not found.");
        //     }
        // }

        // public async Task DeleteMenuItemAsync(int truckId, int itemId)
        // {
        //     var truck = await _context.TruckInfos.GetTruckInfo(truckId);
        //     if (truck != null)
        //     {
        //         var menuItemToDelete = truck.MenuItems.FirstOrDefault(item => item.ItemId == itemId);
        //         if (menuItemToDelete != null)
        //         {
        //             truck.MenuItems.Remove(menuItemToDelete);
        //             await _context.SaveChangesAsync();
        //         }
        //         else
        //         {
        //             throw new InvalidOperationException("Menu item not found.");
        //         }
        //     }
        //     else
        //     {
        //         throw new InvalidOperationException("Truck not found.");
        //     }
        // }

    }
}