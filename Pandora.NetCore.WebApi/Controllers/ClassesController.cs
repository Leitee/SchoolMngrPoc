using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Data.Dals;
using Pandora.NetStandard.Model.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetCore.WebApi.Controllers
{
    public class ClassesController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IClassSvc _classSvc;

        public ClassesController(SchoolDbContext context, IClassSvc classSvc)
        {
            _context = context;
            _classSvc = classSvc;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var response = await _classSvc.GetAllAsync();
            return View(response.Data);
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _classSvc.GetByIdAsync(id.Value);
            return View(response.Data);
        }

        // GET: Classes/Create
        public async Task<IActionResult> Create()
        {
            var classes = await _classSvc.GetAllAsync();
            ViewData["GradeId"] = new SelectList(classes.Data, "GradeId", "Name");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Shift,GradeId")] Class pClass)
        {
            if (ModelState.IsValid)
            {
                var response = await _classSvc.CreateAsync(pClass);
                pClass = response.Data;
                return RedirectToAction(nameof(Index));
            }
            ViewData["GradeId"] = new SelectList((await _classSvc.GetAllAsync()).Data, "GradeId", "Name", pClass.GradeId);
            return View(pClass);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _classSvc.GetByIdAsync(id.Value);

            ViewData["GradeId"] = new SelectList((await _classSvc.GetAllAsync()).Data, "GradeId", "Name", response.Data.GradeId);
            return View(response.Data);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Shift,GradeId")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
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
            ViewData["GradeId"] = new SelectList(_context.Grades, "GradeId", "Name", @class.GradeId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(c => c.Grade)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @class = await _context.Classes.FindAsync(id);
            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
