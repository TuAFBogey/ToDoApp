using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Core.Enums;

namespace ToDoApp.Web.DTOs
{
    public class ToDoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsComplete { get; set; }
        public Period Period { get; set; }
    }
}
