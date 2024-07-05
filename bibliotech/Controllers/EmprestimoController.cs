using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace bibliotech.Controllers
{
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoRepository _emprestimoService;
        private readonly ILivroRepository _livroService;
        private readonly IUsuarioRepository _usuarioService;

        public EmprestimoController(IEmprestimoRepository emprestimoService, ILivroRepository livroService, IUsuarioRepository usuarioService)
        {
            _emprestimoService = emprestimoService ?? throw new ArgumentNullException(nameof(emprestimoService));
            _livroService = livroService ?? throw new ArgumentNullException(nameof(livroService));
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }

        public async Task<IActionResult> Index()
        {
            var emprestimos = await _emprestimoService.GetAll();
            return View(emprestimos);
        }

        public async Task<IActionResult> Create()
        {
            var livros = await _livroService.GetAll();
            var usuarios = await _usuarioService.GetAll();

            ViewBag.Livros = new SelectList(livros, "ID", "Titulo");
            ViewBag.Usuarios = new SelectList(usuarios, "ID", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _emprestimoService.Add(emprestimo);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Ocorreu um erro ao salvar o empréstimo: {ex.Message}");
                }
            }

            // Se houver erro de validação ou exceção ao salvar, recupere os dados necessários novamente
            var livros = await _livroService.GetAll();
            var usuarios = await _usuarioService.GetAll();

            ViewBag.Livros = new SelectList(livros, "ID", "Titulo", emprestimo.LivroID);
            ViewBag.Usuarios = new SelectList(usuarios, "ID", "Nome", emprestimo.UsuarioID);

            return View(emprestimo); // Retorna a view com o objeto emprestimo
        }

        public async Task<IActionResult> Edit(int id)
        {
            var emprestimo = await _emprestimoService.GetById(id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            var livros = await _livroService.GetAll();
            var usuarios = await _usuarioService.GetAll();

            ViewBag.Livros = new SelectList(livros, "ID", "Titulo", emprestimo.LivroID);
            ViewBag.Usuarios = new SelectList(usuarios, "ID", "Nome", emprestimo.UsuarioID);

            return View(emprestimo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Emprestimo emprestimo)
        {
            if (id != emprestimo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _emprestimoService.Update(emprestimo);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Ocorreu um erro ao atualizar o empréstimo: {ex.Message}");
                }
            }

            var livros = await _livroService.GetAll();
            var usuarios = await _usuarioService.GetAll();

            ViewBag.Livros = new SelectList(livros, "ID", "Titulo", emprestimo.LivroID);
            ViewBag.Usuarios = new SelectList(usuarios, "ID", "Nome", emprestimo.UsuarioID);

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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _emprestimoService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocorreu um erro ao excluir o empréstimo: {ex.Message}");
                return View(await _emprestimoService.GetById(id));
            }
        }
    }
}
