using bibliotech.Models;
using bibliotech.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace bibliotech.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroService;

        public LivroController(ILivroRepository livroService)
        {
            _livroService = livroService;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _livroService.GetAll();
            return View(livros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                await _livroService.Add(livro);
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var livro = await _livroService.GetById(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Livro livro)
        {
            if (id != livro.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _livroService.Update(livro);
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _livroService.GetById(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _livroService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
