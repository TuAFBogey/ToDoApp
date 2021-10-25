using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.API.DTOs;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly IMapper _mapper;

        public ToDoListController(IToDoService toDoService, IMapper mapper)
        {
            _toDoService = toDoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var toDo= await _toDoService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var toDoList = await _toDoService.GetByIdAsync(id);
            return Ok(_mapper.Map<ToDoDTO>(toDoList));
        }

        [HttpGet("IsCompleted")]
        public async Task<IActionResult> GetCompleted(bool isComplete)
        {
            var toDo = await _toDoService.GetIsCompleteAsync(isComplete);
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));
        }

        [HttpGet("period")]
        public async Task<IActionResult> GetPeriod(Period period)
        {
            var toDo = await _toDoService.GetByPeriodAsync(period);
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ToDoDTO toDoListDto)
        {
            var newToDoList = await _toDoService.AddAsync(_mapper.Map<ToDo>(toDoListDto));
            return Created(string.Empty, _mapper.Map<ToDoDTO>(newToDoList));
        }

        [HttpPut]
        public IActionResult Update(ToDoDTO toDoListDto)
        {
            var toDos = _toDoService.Update(_mapper.Map<ToDo>(toDoListDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var toDoList = await _toDoService.GetByIdAsync(id);
            _toDoService.Remove(toDoList);
            return NoContent();
        }
    }
}
