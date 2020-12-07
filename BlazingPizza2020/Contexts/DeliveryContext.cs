using BlazingPizza2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Contexts
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> data) : base(data)
        {

        }

        public DbSet<Delivery> Delivery { get; set; }
    }
}
