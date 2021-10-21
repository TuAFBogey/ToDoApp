using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoApp.Core.Models
{
    public enum Period
    {
        Daily=1,
        Weekly=2,
        Monthl=3
    }
    public class ToDoList
    {
        [Key]
        public int ToDoId { get; set; }
        public string ToDoName { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsComplete { get; set; }
        public Period Period { get; set; }
    }
}
