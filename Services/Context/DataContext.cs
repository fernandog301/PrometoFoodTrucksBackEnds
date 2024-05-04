using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrometoFoodTrucksBackEnds.Models;
using static PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel;

namespace PrometoFoodTrucksBackEnds.Services.Context;

    public class DataContext : DbContext
    {
        public DbSet<UserModel>UserInfo{ get; set; }
        // public DbSet<FoodTrucksIteamsModel>TruckInfo{ get; set; }

        public DbSet<FoodTrucksIteamsModel>TruckInfos{ get; set; }
        // public DbSet<Geometry>Geometry{ get; set; }
        // public DbSet<Properties>Properties{ get; set; }
        // public DbSet<MenuItem>MenuItem{ get; set; }
        // public DbSet<Location>Location{ get; set; }


        public DataContext(DbContextOptions options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // SeedData(modelBuilder);
        }


        //     private void SeedData(ModelBuilder modelBuilder)
        //     {
        //         var defaultUsers = new List<FoodTrucksIteamsModel>()
        //         {
        //             new FoodTrucksIteamsModel()
        //             {

        //                 Properties = new FoodTrucksProperties
        //                 {
        //                     address = "Teachers College of San Joaquin",
        //                     city= "Stockton",
        //                     state= "CA",
        //                     zip= 95206,
        //                     name= "truckName",
        //                     image= "imageLink",
        //                     schedule= "their schedule",
        //                     description= "description",
        //                     category= "category",
        //                     menuItems = new List<MenuItem>
        //                     {
        //                         new MenuItem
        //                         {
        //                             itemId= 1,
        //                             itemName= "itemName",
        //                             itemPrice= 0.0,
        //                         },
        //                         new MenuItem
        //                         {
        //                             itemId= 2,
        //                             itemName= "itemName",
        //                             itemPrice= 0.0
        //                         },
        //                         new MenuItem
        //                         {
        //                             itemId= 3,
        //                             itemName= "itemName",
        //                             itemPrice= 0.0
        //                         },
        //                         new MenuItem
        //                         {
        //                             itemId = 4,
        //                             itemName= "itemName",
        //                             itemPrice= 0.0
        //                         },
        //                         new MenuItem
        //                         {
        //                             itemId= 5,
        //                             itemName= "itemName",
        //                             itemPrice= 0.0
        //                         },
        //                         new MenuItem
        //                         {
        //                             itemId= 6,
        //                             itemName= "itemName",
        //                             itemPrice= 0.0
        //                         }
        //                     }
        //         }
        //     }
        // };

        // modelBuilder.Entity<FoodTrucksIteamsModel>().HasData(defaultUsers);
        // }
    }
    
            
                

        
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
            
    
