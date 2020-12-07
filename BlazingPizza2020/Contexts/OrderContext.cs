using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza2020.Models;

namespace BlazingPizza2020.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> data) : base(data)
        {

        }

        public DbSet<Pedido> Order { get; set; }
    }
}
