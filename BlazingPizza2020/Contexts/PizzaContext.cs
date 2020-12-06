using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza2020.Models;

namespace BlazingPizza2020.Contexts
{
    public class PizzaContext : DbContext
    {
        public PizzaContext(DbContextOptions<PizzaContext> data) : base(data)
        {

        }

        public DbSet<Pizza> Pizza { get; set; }

    }
}
