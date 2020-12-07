using BlazingPizza2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Contexts
{
    public class SizeContext : DbContext 
    {
        public SizeContext(DbContextOptions<SizeContext> data) : base(data)
        {

        }

        public DbSet<Size> Size { get; set; }
    }
}
