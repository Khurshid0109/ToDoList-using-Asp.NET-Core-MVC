using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ToDo_List_With_MVC.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required,MaxLength(50),MinLength(1)]
        public string Name { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;

    }
}
