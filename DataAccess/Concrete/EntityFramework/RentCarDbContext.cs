﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentCarDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = CarRentalDb; Integrated Security = True;");
        }

        public DbSet<Car> Car { get; set; }
        public DbSet <Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }

    }
}
