using bibliotech.Interfaces;
using bibliotech.Models;
using bibliotech.Services;
using Microsoft.AspNetCore.Mvc;

namespace bibliotech.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaService;

        public CategoriaController(ICategoriaRepository categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaService.GetAll();
            return View(categorias);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.Add(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _categoriaService.Update(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
