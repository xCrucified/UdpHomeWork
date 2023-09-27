using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_access.Entities;
using data_access.Utilities;
using data_access.Utilities.Seeders;
using Microsoft.EntityFrameworkCore;

namespace AssistantDb.DatabaseContext
{
    public class AssistantDb : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AssistantDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            optionsBuilder.UseSqlServer(conn);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }
        //Tables
        public DbSet<Phrase> Phrase { get; set; }
        public DbSet<Question> Question { get; set; }
    }
}
