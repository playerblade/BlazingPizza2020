using BlazingPizza2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Contexts
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> data) : base(data)
        {

        }

        public DbSet<Client> Client { get; set; }
    }
}
