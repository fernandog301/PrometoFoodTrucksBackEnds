using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrometoFoodTrucksBackEnds.Models;

namespace PrometoFoodTrucksBackEnds.Services.Context
{
    public class DataContext : DbContext
    {
        public DbSet<UserModel>UserInfo{ get; set; }
        public DbSet<AppIteamModels>AppIteam{ get; set; }

        public DataContext(DbContextOptions options): base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}