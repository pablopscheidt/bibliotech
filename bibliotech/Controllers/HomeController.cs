using bibliotech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using bibliotech.Data;

namespace bibliotech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BibliotecaContext _context;

        public HomeController(ILogger<HomeController> logger, BibliotecaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> TestDatabaseConnection()
        {
            try
            {
                await _context.Database.OpenConnectionAsync();
                _context.Database.CloseConnection();
                return Content("Conexão ao banco de dados bem-sucedida.");
            }
            catch (Exception ex)
            {
                return Content($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }
}
