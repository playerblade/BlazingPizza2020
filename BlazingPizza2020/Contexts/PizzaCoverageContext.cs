using BlazingPizza2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Contexts
{
    public class PizzaCoverageContext : DbContext
    {
        public PizzaCoverageContext(DbContextOptions<PizzaCoverageContext> data) : base(data)
        {

        }

        public DbSet<PizzaCoverage> PizzaCoverage { get; set; }
    }
}
