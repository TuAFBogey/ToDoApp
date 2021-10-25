using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;

namespace ToDoApp.Core.Services
{
    public interface IToDoService : IService<ToDo>
    {
        Task<IEnumerable<ToDo>> GetCompletedAsync();

        Task<IEnumerable<ToDo>> GetNotCompletedAsync();

        Task<IEnumerable<ToDo>> GetByPeriodAsync(Period period);
    }
}
