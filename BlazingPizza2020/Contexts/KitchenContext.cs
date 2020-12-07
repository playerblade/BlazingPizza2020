using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza2020.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza2020.Contexts
{
    public class KitchenContext : DbContext
    {
        public KitchenContext(DbContextOptions<KitchenContext> data) : base(data)
        {

        }

        public DbSet<Kitchen> Kitchen { get; set; }
    }
}
