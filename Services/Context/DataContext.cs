using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrometoFoodTrucksBackEnds.Models;
using PrometoFoodTrucksBackEnds.Models.DTO;

namespace PrometoFoodTrucksBackEnds.Services.Context;

    public class DataContext : DbContext
    {
        public DbSet<UserModel>UserInfo{ get; set; }
        public DbSet<UserModel.MenuItem> MenuItems { get; set; }


        

        public DataContext(DbContextOptions <DataContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.UserID);

             // Configuring the primary key for MenuItem
            modelBuilder.Entity<UserModel.MenuItem>()
                .HasKey(mi => mi.itemId);

            // Configuring relationships, if any
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.menuItems)
                .WithOne()
                .HasForeignKey(mi => mi.FoodTrucksID);
            
            base.OnModelCreating(modelBuilder);


        }
    }


            
    
