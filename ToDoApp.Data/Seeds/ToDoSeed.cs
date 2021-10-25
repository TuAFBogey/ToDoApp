using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;

namespace ToDoApp.Data.Seeds
{
    public class ToDoSeed : IEntityTypeConfiguration<ToDo>
    {
        private readonly int[] _ids;
        public ToDoSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasData(
                new ToDo { Id = 1, Name = "Learn SQL", DateTime = DateTime.Parse("24/10/2021 8:00"), IsComplete = false, Period = Period.Monthly },
                    new ToDo { Id = 2, Name = "Learn MVC", DateTime = DateTime.Parse("25/11/2021 8:00"), IsComplete = false, Period = Period.Monthly },
                        new ToDo { Id = 3, Name = "Write Data Layer", DateTime = DateTime.Parse("24/10/2021 8:00"), IsComplete = false, Period = Period.Weekly },
                            new ToDo { Id = 4, Name = "Develop the ToDoApp", DateTime = DateTime.Parse("26/10/2021 8:00"), IsComplete = true, Period = Period.Weekly },
                                new ToDo { Id = 5, Name = "Check the MailBox", DateTime = DateTime.Parse("24/10/2021 8:00"), IsComplete = true, Period = Period.Daily },
                                    new ToDo { Id = 6, Name = "Something", DateTime = DateTime.Parse("28/10/2021 8:00"), IsComplete = true, Period = Period.Daily },
                                        new ToDo { Id = 7, Name = "BlaBla", DateTime = DateTime.Parse("30/10/2021 8:00"), IsComplete = false, Period = Period.Weekly },
                                            new ToDo { Id = 8, Name = "EtcEtc", DateTime = DateTime.Parse("01/11/2021 8:00"), IsComplete = true, Period = Period.Monthly }
                );
        }
    }
}
