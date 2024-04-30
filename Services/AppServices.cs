using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Services.Context;

namespace PrometoFoodTrucksBackEnds.Services
{
    public class AppServices : ControllerBase
    {
        private readonly DataContext _context;

        public AppServices(DataContext context){
            _context = context;
        }
        public bool AddFoodTruckIteam(AppIteamModels newFoodTruckIteam)
        {
            _context.Add(newFoodTruckIteam);
            return _context.SaveChanges() != 0;
        }
        public IEnumerable<AppIteamModels> GetAllFoodTruckIteam()
        {
            return _context.AppIteam;
        }

        public bool UpdateFoodTruckIteam(AppIteamModels FoodTruckIteamUpdate)
        {
            _context.Update<AppIteamModels>(FoodTruckIteamUpdate);
            return _context.SaveChanges() != 0;
        }

        public bool DeleteFoodTruckIteam(AppIteamModels FoodTruckIteamToDelete)
        {
            FoodTruckIteamToDelete.IsDeleted = true;
            _context.Update<AppIteamModels>(FoodTruckIteamToDelete);
            return _context.SaveChanges() != 0;
        }

        internal bool FoodTruckIteamUpdate(UserModel foodTruckIteamUpdate)
        {
            throw new NotImplementedException();
        }

        

    }
}