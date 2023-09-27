using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Utilities.Seeders
{
    public static class Seeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phrase>().HasData(
            new Phrase { Id = 1, Name = "Hello World"},
            new Phrase { Id = 2, Name = "It's time to shutdown the computer and go to do some exercises!" });
        }
    }
}
