using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Web.ApiService;
using ToDoApp.Web.DTOs;

namespace ToDoApp.Web.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly ToDoApiService _toDoApiService;
        private readonly IMapper _mapper;

        public ToDoListController(ToDoApiService toDoApiService, IMapper mapper)
        {
            _toDoApiService = toDoApiService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var toDos = await _toDoApiService.GetAllAsync();
            return View(_mapper.Map<IEnumerable<ToDoDTO>>(toDos));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoDTO toDoDTO)
        {
            await _toDoApiService.AddAsync(toDoDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var toDo = await _toDoApiService.GetByIdAsync(id);
            return View(_mapper.Map<ToDoDTO>(toDo));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ToDoDTO toDoDTO)
        {
            await _toDoApiService.Update(toDoDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _toDoApiService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
