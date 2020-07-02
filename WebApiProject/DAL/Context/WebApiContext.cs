using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.DAL.Entities;

namespace WebApiProject.DAL.Context
{
    public class WebApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=WebApiDB; integrated security=true");
        }
        public DbSet<Category> Categories { get; set; }
    }
}
