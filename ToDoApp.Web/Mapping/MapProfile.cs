using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;
using ToDoApp.Core.Models;
using ToDoApp.Web.DTOs;

namespace ToDoApp.Web.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ToDo, ToDoDTO>();
            CreateMap<ToDoDTO, ToDo>();
        }
    }
}
