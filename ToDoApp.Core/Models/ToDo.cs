using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ToDoApp.Core.Enums;

namespace ToDoApp.Core.Models
{
    public class ToDo
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsComplete { get; set; }
        public Period Period { get; set; }
    }
}
