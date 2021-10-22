using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class ToDoListRepository : Repository<ToDoList>, IToDoListRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ToDoListRepository(AppDbContext context) : base(context)
        {
        }
    }
}