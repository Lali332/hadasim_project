using HMO.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMO.Data
{
    public class DataContext:DbContext
    {
       public DbSet<PersonalDetails> PersonalDetails { get; set; }
       public DbSet<CoronaDetails> CoronaDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HMO");
        }
    }
}
