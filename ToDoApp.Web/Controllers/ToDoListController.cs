﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Models;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoDTO toDoDTO)
        {
            await _toDoService.AddAsync(_mapper.Map<ToDo>(toDoDTO));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var toDo = await _toDoService.GetByIdAsync(id);
            return View(_mapper.Map<ToDoDTO>(toDo));
        }

        [HttpPost] 
        public IActionResult Update(ToDoDTO toDoDTO)
        {
            _toDoService.Update(_mapper.Map<ToDo>(toDoDTO));
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var toDo = _toDoService.GetByIdAsync(id).Result;
            _toDoService.Remove(toDo);
            return RedirectToAction("Index");
        }
    }
}