using CalculatorWeb.Models;
using CalculatorWeb.Services;
using CalculatorWeb.ViewModels.Home;
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

        public IActionResult Index()
        {
            return View("Welcome");
        }

        public IActionResult Create(UserModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Calc");
            }

            ViewBag.Error = "Hay campos sin completar";
            return View("Welcome", model);
        }

        [HttpGet]
        [Route("Calc")]
        public IActionResult Calc()
        {
            CalcViewModel model = new CalcViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("Calc")]
        public IActionResult Calc1(CalcViewModel model)
        {
            CalculateModelService service = new CalculateModelService();

            model.Result = service.CalculateResult();
            return View("Calc", model);
        }
    }
}