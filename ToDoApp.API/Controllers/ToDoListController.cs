using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IToDoListService _toDoListService;
        private readonly IMapper _mapper;

        public ToDoListController(IToDoListService toDoListService, IMapper mapper)
        {
            _toDoListService = toDoListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var toDoLists = await _toDoListService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ToDoListDTO>>(toDoLists));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var toDoList = await _toDoListService.GetByIdAsync(id);
            return Ok(_mapper.Map<ToDoListDTO>(toDoList));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ToDoListDTO toDoListDto)
        {
            var newToDoList = await _toDoListService.AddAsync(_mapper.Map<ToDoList>(toDoListDto));
            return Created(string.Empty, _mapper.Map<ToDoListDTO>(newToDoList));
        }

        [HttpPut]
        public IActionResult Update(ToDoListDTO toDoListDto)
        {
            var toDoLists = _toDoListService.Update(_mapper.Map<ToDoList>(toDoListDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var toDoList = await _toDoListService.GetByIdAsync(id);
            _toDoListService.Remove(toDoList);
            return NoContent();
        }
    }
}
