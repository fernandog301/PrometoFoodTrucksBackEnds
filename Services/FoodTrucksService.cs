using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrometoFoodTrucksBackEnds.Controllers;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Services.Context;

namespace PrometoFoodTrucksBackEnds.Services
{
    public class FoodTrucksService 
    {
        
        private readonly DataContext _context;
        public FoodTrucksService(DataContext context){
            _context = context;
        }

        public IEnumerable<FoodTrucksIteamsModel> GetAllFoodTrucks(int ID)
        {
            return _context.FoodTrucksInfo.Where(FoodTruck => FoodTruck.ID == ID).ToList();
        }

        

        public FoodTrucksIteamsModel GetFoodTruckById(int id){
            return _context.FoodTrucksInfo.SingleOrDefault(FoodTruck => FoodTruck.ID == id);
        }

        // public bool CreateNewFoodTruck(int ID, FoodTrucksIteamsModel newFoodTruck)
        // {
        //     // Ensure the club exists (Might want to add error handling if club doesn't exist)
        //     var FoodTruck = _context.FoodTrucksInfo.FirstOrDefault(c => c.ID == ID);
        //     if (FoodTruck == null)
        //     {
        //         // Club not found
        //         return false; 
        //     }
          
        //     newFoodTruck.ID = ID;
        //     Console.WriteLine(newFoodTruck);

        //     _context.FoodTrucksInfo.Add(newFoodTruck);
        //     return _context.SaveChanges() != 0; 
        // }

        

        public bool DoesUserExist(string FoodTruckName)
        {
            return _context.FoodTrucksInfo.SingleOrDefault(user => user.FoodTruckName == FoodTruckName) != null;
        }

        public bool AddFoodTruck(FoodTrucksIteamsModel newFoodTruck)
        {
            // bool result = false;

            // if(!DoesUserExist(AddFoodTruck.FoodTruckName)){

            //     FoodTrucksIteamsModel newFoodTruck = new FoodTrucksIteamsModel();

            //     newFoodTruck.ID = AddFoodTruck.ID;
                // newFoodTruck.FoodTruckName = AddFoodTruck.FoodTruckName;
                // newFoodTruck.FoodTruckCategory = AddFoodTruck.FoodTruckCategory;
                // newFoodTruck.ImageUrl = AddFoodTruck.ImageUrl;
                // newFoodTruck.Description = AddFoodTruck.Description;
                // newFoodTruck.Email = AddFoodTruck.Email;
                // newFoodTruck.location = AddFoodTruck.location;
                // newFoodTruck.FoodTruckPrices = AddFoodTruck.FoodTruckPrices;
                // newFoodTruck.FoodTruckMenu = AddFoodTruck.FoodTruckMenu;
                // newFoodTruck.FoodTruckHours = AddFoodTruck.FoodTruckHours;
                // newFoodTruck.FoodTruckReviews = AddFoodTruck.FoodTruckReviews;
                // newFoodTruck.IsThere = AddFoodTruck.IsThere;
                // newFoodTruck.IsDeleted = AddFoodTruck.IsDeleted;

                _context.Add(newFoodTruck);
                return _context.SaveChanges() !=0;

                // result = true;
            // }
            // return result;
        }

        public bool DeletePFoodTruck(FoodTrucksIteamsModel FoodTruckToDelete){
            FoodTruckToDelete.IsDeleted = true;
            _context.Update<FoodTrucksIteamsModel>(FoodTruckToDelete);
            return _context.SaveChanges() != 0;
        }


        public bool UpdateFoodTrucksItems(FoodTrucksIteamsModel FoodTruckToUpdate){
            _context.Update<FoodTrucksIteamsModel>(FoodTruckToUpdate);
            return _context.SaveChanges() != 0;
        }
        
        public bool UpdateFoodTrucks(int id, string FoodTruckName)
        {
            FoodTrucksIteamsModel existingFoodTruck = GetFoodTruckById(id);

            bool result = false;

            if (existingFoodTruck != null)
            {
                existingFoodTruck.FoodTruckName = FoodTruckName;
                _context.Update<FoodTrucksIteamsModel>(existingFoodTruck);
                result = _context.SaveChanges() != 0;

            }
            return result;
        }


        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTruckByCategory(int ID, string FoodTruckCatagory)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(FoodTruck => FoodTruck.FoodTruckCategory == FoodTruckCatagory);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTruckHours(int FoodTruckHours)
        // {
        //     return _context.FoodTrucksInfo.Where(hours => hours.FoodTruckHours == FoodTruckHours).ToList();
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTruckMenu(int ID, string FoodTruckMenu)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.FoodTruckMenu == FoodTruckMenu);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTrucklocation(int ID, string location)
        // {   
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.location == location);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTrucksPrices(int ID, int Price)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.FoodTruckPrices == Price);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTrucksDays(int ID, string Day)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.FoodTruckDays == Day);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTruckName(int ID, string FoodTruckName)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.FoodTruckName == FoodTruckName);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTrucksImageUrl(int ID, string ImageUrl)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.ImageUrl == ImageUrl);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTrucksDescription(int ID, string Description)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.Description == Description);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTrucksEmail(int ID, string Email)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.Email == Email);
        // }

        // public IEnumerable<FoodTrucksIteamsModel> GetFoodTrucksFoodTruckReviews(int ID, string FoodTruckReviews)
        // {
        //     var allItems = GetAllFoodTrucks(ID).ToList();
        //     return allItems.Where(items => items.FoodTruckReviews == FoodTruckReviews);
        // }

    }
}