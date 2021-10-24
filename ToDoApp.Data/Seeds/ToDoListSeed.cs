using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;

namespace ToDoApp.Data.Seeds
{
    public class ToDoListSeed : IEntityTypeConfiguration<ToDoList>
    {
        private readonly int[] _ids;
        public ToDoListSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            builder.HasData(
                new ToDoList { ToDoId = 1, ToDoName = "Learn SQL", DateTime = DateTime.Parse("24/10/2021 8:00"), IsComplete = false, Period = Period.Monthly },
                    new ToDoList { ToDoId = 2, ToDoName = "Learn MVC", DateTime = DateTime.Parse("25/11/2021 8:00"), IsComplete = false, Period = Period.Monthly },
                        new ToDoList { ToDoId = 3, ToDoName = "Write Data Layer", DateTime = DateTime.Parse("24/10/2021 8:00"), IsComplete = false, Period = Period.Weekly },
                            new ToDoList { ToDoId = 4, ToDoName = "Develop the ToDoApp", DateTime = DateTime.Parse("26/10/2021 8:00"), IsComplete = true, Period = Period.Weekly },
                                new ToDoList { ToDoId = 5, ToDoName = "Check the MailBox", DateTime = DateTime.Parse("24/10/2021 8:00"), IsComplete = true, Period = Period.Daily },
                                    new ToDoList { ToDoId = 6, ToDoName = "Something", DateTime = DateTime.Parse("28/10/2021 8:00"), IsComplete = true, Period = Period.Daily },
                                        new ToDoList { ToDoId = 7, ToDoName = "BlaBla", DateTime = DateTime.Parse("30/10/2021 8:00"), IsComplete = false, Period = Period.Weekly },
                                            new ToDoList { ToDoId = 8, ToDoName = "EtcEtc", DateTime = DateTime.Parse("01/11/2021 8:00"), IsComplete = true, Period = Period.Monthly }
                );
        }
    }
}
