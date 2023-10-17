using ToDo_List_With_MVC.Models;

namespace ToDo_List_With_MVC.ViewModel
{
    public class ToDoViewModel
    {
        public List<ToDoItem> TodoList { get; set; }
        public ToDoItem Todo { get; set; }
    }
}
