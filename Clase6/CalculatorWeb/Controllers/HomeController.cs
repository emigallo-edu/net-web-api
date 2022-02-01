using System.Diagnostics;
using System.Threading.Tasks;
using CalculatorWeb.Connection;
using CalculatorWeb.Models;
using CalculatorWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            UserModel model = new UserModel();
            //model.Title = "Hola, bienvenido a la calculadora.";

            RestConnection rest = new RestConnection("http://localhost:55000");

            WelcomeMessage result = await rest.GetAsync<WelcomeMessage>("calc");
            model.Title = result.Message;

            return View("Welcome", model);
        }

        [HttpPost]
        public IActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Calc");
            }

            ViewBag.Error = "Hay campos sin completar";

            return View("Welcome", model);
        }

        public IActionResult Calc()
        {
            CalcViewModel viewModel = new CalcViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("Calculate")]
        public IActionResult Calculate()
        {
            // Llamar a la API para calcular el resultado
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
    }
}