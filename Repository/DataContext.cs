using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg_practice.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg_practice.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character>? Characters { get; set; }
    }
}