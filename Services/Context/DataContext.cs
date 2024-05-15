using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Models.DTO;
using static PrometoFoodTrucksBackEnds.Models.FoodTrucksIteamsModel;

namespace PrometoFoodTrucksBackEnds.Services.Context;

    public class DataContext : DbContext
    {
        public DbSet<UserModel>UserInfo{ get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        // public DbSet<MenuItem>? menuItems { get; set; }

         // Add MenuItem DbSet
        // public DbSet<MenuDTO> Menus { get; set; } // Add MenuDTO DbSet
        public DbSet<FoodTrucksIteamsModel>TruckInfos{ get; set; }

        

        public DataContext(DbContextOptions <DataContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            // SeedData(modelBuilder);
            modelBuilder.Entity<MenuItem>()
            
            // .HasKey(m => m.itemId)
            // .HasMany(menu => menu.Menu) // Menu has many Items
            .HasOne(u  => u.FoodTrucks) 
            .WithMany(u => u.menuItems)
            .HasForeignKey(u => u.FoodTrucksID);
            // Item belongs to one Menu
            // .HasForeignKey(item => item.MenuDTOId); // Foreign key property
            
            modelBuilder.Entity<MenuItem>()
            .Property(u => u.itemName)
            .HasMaxLength(100);

            modelBuilder.Entity<MenuItem>()
            .Property(u => u.itemPrice)
            .HasColumnType("decimal(18,2)");


        }
    }


            
    
