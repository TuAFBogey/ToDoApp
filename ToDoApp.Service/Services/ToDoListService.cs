using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;
using ToDoApp.Core.Repositories;
using ToDoApp.Core.Services;
using ToDoApp.Core.UnitOfWork;

namespace ToDoApp.Service.Services
{
    public class ToDoListService : Service<ToDoList>, IToDoListService
    {
        public ToDoListService(IUnitOfWork unitOfWork, IRepository<ToDoList> repository) : base(unitOfWork, repository)
        {
        }

    }
}
