using Microsoft.AspNetCore.Mvc;
using ToDo_List_With_MVC.Models;
using ToDo_List_With_MVC.ViewModel;

namespace ToDo_List_With_MVC.Services
{
    public interface IToDoService
    {
        ToDoViewModel GetAll();
        ToDoItem GetById(int id);
        void DeleteTogetherAll();
    }
}
