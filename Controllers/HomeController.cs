using Microsoft.AspNetCore.Mvc;
using ToDo_List_With_MVC.Data;
using ToDo_List_With_MVC.Models;
using ToDo_List_With_MVC.Services;

namespace ToDo_List_With_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IToDoService _service;

        public HomeController(DataContext context,IToDoService service)
        {
            _context = context;
            _service = service;
        }

       
        public IActionResult Index()
        {
            var todoListViewModel = _service.GetAll();
            return View(todoListViewModel);
        }

        [HttpGet]
        public JsonResult PopulateForm(int id)
        {
            var todo = _service.GetById(id);
            return Json(todo);
        }

        [HttpGet]
        public IActionResult DeleteAll()
        {
            _service.DeleteTogetherAll();
            return RedirectToAction("index");
        }

        public IActionResult Insert(ToDoItem todo)
        {
            try
            {
                if (todo != null)
                {
                    _context.ToDoItems.Add(todo);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("index");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                var todoToDelete = _context.ToDoItems.Find(id);
                if (todoToDelete != null)
                {
                    _context.ToDoItems.Remove(todoToDelete);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(new { });
        }

        public IActionResult Update(ToDoItem todo)
        {

            try
            {
                var todoToUpdate = _context.ToDoItems.FirstOrDefault(item =>item.Id==todo.Id);
                if (todoToUpdate != null)
                {
                    todoToUpdate.CreatedTime= DateTime.Now;
                    todoToUpdate.Name = todo.Name;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("insert");
        }
    }
}