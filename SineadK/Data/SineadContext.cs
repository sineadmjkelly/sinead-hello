using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SineadK.Data.Entities;

namespace SineadK.Data
{
    public class SineadContext : DbContext
    {
        public SineadContext(DbContextOptions<SineadContext> options): base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
