using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrometoFoodTrucksBackEnds.Models;

namespace PrometoFoodTrucksBackEnds.Services.Context;

    public class DataContext : DbContext
    {
        public DbSet<UserModel>UserInfo{ get; set; }
        public DbSet<AppIteamModels>AppIteam{ get; set; }
        public DbSet<FoodTrucksIteamsModel>FoodTrucksInfo{ get; set; }

        public DataContext(DbContextOptions options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // SeedData(modelBuilder);
        }


        // private void SeedData(ModelBuilder builder)
        // {
        //     var defaultUsers = new List<UserModel>()
        //     {
        //         new UserModel()
        //         {
                    
        //         }

        // };
        // // builder.Entity<FoodTrucksIteamsModel>().HasData(defaultTrucks);
        //     // Configures intial data from defaultUsers by using Entity, which specifies the table we want to configure initial data
        //     // Has Data tells Entity Framework to include the provided data

        //     var defaultAppItems = new List<AppIteamModels>()
        //     {
        //         new AppIteamModels()
        //         {
                    
        //         },

        //     };
        //     builder.Entity<AppIteamModels>().HasData(defaultAppItems);

        //         var defaultTrucks = new List<FoodTrucksIteamsModel>()
        //         {
        //             new FoodTrucksIteamsModel()
        //             {
                            
        //             },
        //         };
            
    }
