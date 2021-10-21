using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;

namespace ToDoApp.API.DTOs
{
    public class ToDoListDTO
    {
        public int ToDoId { get; set; }
        public string ToDoName { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsComplete { get; set; }
        public Period Period { get; set; }
    }
}
