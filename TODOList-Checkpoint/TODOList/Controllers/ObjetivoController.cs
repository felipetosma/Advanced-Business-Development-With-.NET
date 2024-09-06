using Microsoft.AspNetCore.Mvc;
using TODOList.Data;
using TODOList.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace TODOList.Controllers
{
    public class ObjetivoController : Controller
    {
        private readonly dbContext _context;

        public ObjetivoController(dbContext context)
        {
            _context = context;
        }

        // GET: Objetivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Objetivos.ToListAsync());
        }

        // GET: Objetivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Objetivo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,DataCriacao")] Objetivo objetivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objetivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(objetivo);
        }

        // GET: Objetivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objetivo = await _context.Objetivos.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }
            return View(objetivo);
        }

        // POST: Objetivo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,DataCriacao")] Objetivo objetivo)
        {
            if (id != objetivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objetivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjetivoExists(objetivo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(objetivo);
        }

        private bool ObjetivoExists(int id)
        {
            return _context.Objetivos.Any(e => e.Id == id);
        }
    }
}
