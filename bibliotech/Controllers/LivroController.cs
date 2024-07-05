using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bibliotech.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroRepository _livroRepository;

        public LivroController(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _livroRepository.GetAll();
            if (livros == null || !livros.Any())
            {
                return RedirectToAction("Create");
            }
            return View(livros);
        }

        public IActionResult Create()
        {
            var livro = new Livro();
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                await _livroRepository.Add(livro);
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var livro = await _livroRepository.GetById(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Livro livro)
        {
            if (id != livro.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _livroRepository.Update(livro);
                return RedirectToAction(nameof(Index));
            }
            return View(livro);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _livroRepository.GetById(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _livroRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
