using bibliotech.Interfaces;
using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace bibliotech.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository _usuarioService;

        public UsuarioController(IUsuarioRepository usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAll();
            return View(usuarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.DataRegistro = DateTime.UtcNow;

                await _usuarioService.Add(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Usuario usuario)
        {
            if (id != usuario.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                usuario.DataRegistro = DateTime.UtcNow;

                await _usuarioService.Update(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _usuarioService.GetById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _usuarioService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
