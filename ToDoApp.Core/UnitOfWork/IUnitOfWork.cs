﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core.Repositories;

namespace ToDoApp.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IToDoListRepository ToDoLists { get; }

        Task CommitAsync();

        void Commit();
    }
}