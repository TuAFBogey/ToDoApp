using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompleted()
        {

            var toDo = await _toDoService.GetCompletedAsync();
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));

            //var completed = await _toDoService.GetAllAsync();
            //return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(completed.Where(x => x.IsComplete == true).ToList()));
        }

        [HttpGet("notCompleted")]
        public async Task<IActionResult> GetNotCompleted()
        {

            var toDo = await _toDoService.GetNotCompletedAsync();
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));

            //var completed = await _toDoService.GetAllAsync();
            //return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(completed.Where(x => x.IsComplete == false).ToList()));
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDaily()
        {
            var toDo = await _toDoService.GetByDailyAsync();
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));
            
            //var completed = await _toDoService.GetAllAsync();
            //return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(completed.Where(x => x.Period == Period.Daily ).ToList()));
        }

        [HttpGet("weekly")]
        public async Task<IActionResult> GetWeekly()
        {
            var toDo = await _toDoService.GetByWeeklyAsync();
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));

            //var completed = await _toDoService.GetAllAsync();
            //return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(completed.Where(x => x.Period == Period.Weekly).ToList()));
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetMonthly()
        {
            var toDo = await _toDoService.GetByMonthlyAsync();
            return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(toDo));

            //var completed = await _toDoService.GetAllAsync();
            //return Ok(_mapper.Map<IEnumerable<ToDoDTO>>(completed.Where(x => x.Period == Period.Monthly).ToList()));
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
