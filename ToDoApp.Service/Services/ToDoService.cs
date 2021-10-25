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
    public class ToDoService : Service<ToDo>, IToDoService
    {
        public ToDoService(IUnitOfWork unitOfWork, IRepository<ToDo> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<IEnumerable<ToDo>> GetIsCompleteAsync(bool isComplete)
        {
            return await _unitOfWork.ToDos.GetIsCompleteAsync(isComplete);
        }

        public async Task<IEnumerable<ToDo>> GetByPeriodAsync(Period period)
        {
            return await _unitOfWork.ToDos.GetByPeriodAsync(period);
        }
    }
}