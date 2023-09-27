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
                new Phrase { Id = 1, Name = "What's up brudda!", QuestionId = 1},
                new Phrase { Id = 2, QuestionId = 2, Name = "It's time to shutdown the computer and go to do some exercises!" },
                new Phrase { Id = 3, QuestionId = 3, Name = "I don't have a personal name because I'm just a computer program created by OpenAI. You can call me \"Assistant\" or anything you prefer. How can I assist you today?" },
                new Phrase { Id = 4, QuestionId = 4, Name = "Pandas are fascinating creatures! The giant panda (Ailuropoda melanoleuca) is a bear native to China, known for its distinctive black and white coat." },
                new Phrase { Id = 5, QuestionId = 5, Name = "Hello World" },
                new Phrase { Id = 6, QuestionId = 6, Name = "I don't have access to real-time information as my knowledge is based on data only up to September 2021. To find out the current time, you can check a clock, watch, or use a device with internet access, such as a computer or smartphone, which typically displays the current time in the system tray or on the lock screen." }
            );
            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, Name = "Hey"},
                new Question { Id = 2, Name = "What's time?" },
                new Question { Id = 3, Name = "What's ur name?" },
                new Question { Id = 4, Name = "What's 'bout pandas?" },
                new Question { Id = 5, Name = "Say something on ur language" },
                new Question { Id = 6, Name = "What's time now?" }

            );
        }
    }
}
