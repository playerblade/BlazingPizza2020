using BlazingPizza2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza2020.Contexts
{
    public class CoverageContext : DbContext
    {
        public CoverageContext(DbContextOptions<CoverageContext> data) : base(data)
        {

        }

        public DbSet<Coverage> Coverage { get; set; }
    }
}
