using Microsoft.AspNetCore.Mvc;

namespace TODOList.Controllers
{
    public class TodoController : Controller
    {
        private readonly dbContext _context;
        public TodoController(dbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var AllTodos = _context.TODOs.ToList();
            if (AllTodos == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(AllTodos);
        }
        public IActionResult Create(TODO todo)
        {
            var newTodo = new TODO
            {
                Tarefa = todo.Tarefa,
                Descricao = todo.Descricao,
                feto = todo.feto
            };
            _context.TODOs.Add(newTodo);
            _context.SaveChanges();

            return View();
        }
    }
}
