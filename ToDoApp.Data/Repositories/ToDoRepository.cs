using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Data.Repositories
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }
        public ToDoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ToDo>> GetCompletedAsync()
        {
            return await _appDbContext.ToDos.ToListAsync();
        }

        public async Task<IEnumerable<ToDo>> GetNotCompletedAsync()
        {
            return await _appDbContext.ToDos.ToListAsync();
        }

        public async Task<IEnumerable<ToDo>> GetByPeriodAsync(Period period)
        {
            return await _appDbContext.ToDos.Where(x => x.Period == period).ToListAsync();
        }
    }
}