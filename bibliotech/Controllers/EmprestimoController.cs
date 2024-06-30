using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;

namespace bibliotech.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoRepository _emprestimoService;

        public EmprestimoController(IEmprestimoRepository emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        public async Task<IActionResult> Index()
        {
            var emprestimos = await _emprestimoService.GetAll();
            return View(emprestimos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                await _emprestimoService.Add(emprestimo);
                return RedirectToAction(nameof(Index));
            }
            return View(emprestimo);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var emprestimo = await _emprestimoService.GetById(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Emprestimo emprestimo)
        {
            if (id != emprestimo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _emprestimoService.Update(emprestimo);
                return RedirectToAction(nameof(Index));
            }
            return View(emprestimo);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var emprestimo = await _emprestimoService.GetById(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _emprestimoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
