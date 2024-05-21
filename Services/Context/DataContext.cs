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
        

        

        public DataContext(DbContextOptions <DataContext> options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.UserID);

             // Configuring the primary key for MenuItem
            

            // Configuring relationships, if any

            
            base.OnModelCreating(modelBuilder);


        }
    }


            
    
