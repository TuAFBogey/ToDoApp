using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.DTOs;
using ToDoApp.Core.Models;

namespace ToDoApp.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ToDoList, ToDoListDTO>();
            CreateMap<ToDoListDTO, ToDoList>();
        }
    }
}
