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

        //One DbSet should be related to one table. (in this case I only have one table):
        public DbSet<Car> Car { get; set; } //Car is the object in the Model Class. this should be named Cars
    }
}
