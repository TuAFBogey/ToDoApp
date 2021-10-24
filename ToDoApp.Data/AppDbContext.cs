using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;
using ToDoApp.Data.Seeds;

namespace ToDoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ToDoList> ToDoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TodoListDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoListSeed(new int[] { 1, 2, 3, 4, 5, 6, 7, 8}));

            modelBuilder
                .Entity<ToDoList>()
                .Property(e => e.Period)
                .HasConversion(
                    v => v.ToString(),
                    v => (Period)Enum.Parse(typeof(Period), v));


            
            
        }
    }
}
