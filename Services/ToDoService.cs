using ToDo_List_With_MVC.Data;
using ToDo_List_With_MVC.Models;
using ToDo_List_With_MVC.ViewModel;

namespace ToDo_List_With_MVC.Services
{
    public class ToDoService : IToDoService
    {
        private readonly DataContext _context;

        public ToDoService(DataContext context)
        {
            _context = context;
        }

        public void DeleteTogetherAll()
        {
            var items = _context.ToDoItems.ToList();
            if(items is not null)
            _context.ToDoItems.RemoveRange(items);
            _context.SaveChanges();
        }

        public ToDoViewModel GetAll()
        {
            List<ToDoItem> todoList = new();

            todoList = _context.ToDoItems.ToList();

            return new ToDoViewModel
            {
                TodoList = todoList
            };
        }

        public ToDoItem GetById(int id)
        {
            var todo = _context.ToDoItems.FirstOrDefault(item => item.Id == id);
            if (todo == null)
                throw new Exception("There is no Item with this Id!");
            return todo;
        }
    }
}
