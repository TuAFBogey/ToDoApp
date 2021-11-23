﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Services;
using ToDoApp.Web.DTOs;

namespace ToDoApp.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IMapper _mapper;

        public ToDoListController(IToDoService toDoService, IMapper mapper)
        {
            _toDoService = toDoService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var toDos = await _toDoService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ToDoDTO>>(toDos));
        }
    }
}
