using JunkCarsApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JunkCarsApp.Data
{
    public class CarsContext : DbContext 
    {
        public CarsContext (DbContextOptions<CarsContext> options) : base(options)
        {
        }

        public DbSet<Car> Car { get; set; } //Car is the object in the Model Class
    }
}
