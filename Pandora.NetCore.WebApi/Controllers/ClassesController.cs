using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services.Contracts;
using System.Threading.Tasks;

namespace Pandora.NetCore.WebApi.Controllers
{
    public class ClassesController : Controller
    {
        private readonly IClassSvc _classSvc;
        private readonly IGradeSvc _gradeSvc;

        public ClassesController(IClassSvc classSvc, IGradeSvc gradeSvc)
        {
            _classSvc = classSvc;
            _gradeSvc = gradeSvc;
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
            ViewData["Grades"] = new SelectList(_gradeSvc.GetAllAsync().Result.Data, "Id", "Name");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassDto pClass)
        {
            if (ModelState.IsValid)
            {
                var response = await _classSvc.CreateAsync(pClass);
                pClass = response.Data;
                return RedirectToAction(nameof(Index));
            }
            ViewData["Grades"] = new SelectList((await _gradeSvc.GetAllAsync()).Data, "Id", "Name", pClass.GradeId);
            return View(pClass);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var response = await _classSvc.GetByIdAsync(id.Value);

            ViewData["Grades"] = new SelectList((await _gradeSvc.GetAllAsync()).Data, "Id", "Name", response.Data.GradeId);
            return View(response.Data);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassDto pClass)
        {
            if (id != pClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var resul = await _classSvc.UpdateAsync(pClass);
                if (resul.Data)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Grades"] = new SelectList((await _gradeSvc.GetAllAsync()).Data, "Id", "Name", pClass.GradeId);
            return View(pClass);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var response = await _classSvc.GetByIdAsync(id.Value);

            ViewData["Grades"] = new SelectList((await _gradeSvc.GetAllAsync()).Data, "Id", "Name", response.Data.GradeId);
            return View(response.Data);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resul = await _classSvc.DeleteAsync(id);
            if (resul.Data)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
