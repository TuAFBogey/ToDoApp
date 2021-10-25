using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.UnitOfWork;
using ToDoApp.Data.Repositories;

namespace ToDoApp.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ToDoRepository _toDoListRepository;
        public IToDoRepository ToDos => _toDoListRepository = _toDoListRepository ?? new ToDoRepository(_context);

        public UnitOfWork(AppDbContext _appDbContext)
        {
            _context = _appDbContext;
        }

        public void Commit() //savechange
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync() //savechangeasync
        {
            await _context.SaveChangesAsync();
        }
    }
}
