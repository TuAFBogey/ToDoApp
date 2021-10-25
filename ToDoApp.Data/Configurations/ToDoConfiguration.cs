using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;

namespace ToDoApp.Data.Configurations
{
    public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
    {
        public void Configure(EntityTypeBuilder<ToDo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);

            builder
                .Property(e => e.Period)
                .HasConversion(
                v => v.ToString(),
                v => (Period)Enum.Parse(typeof(Period), v));
            
            builder.Property(x => x.IsComplete).HasDefaultValue(false);
            builder.Property(x => x.Period).HasDefaultValue(Period.Daily);
            builder.Property(x => x.DateTime).HasDefaultValueSql("getdate()");

            
        }
    }
}
