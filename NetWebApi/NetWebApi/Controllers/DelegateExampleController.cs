using Microsoft.AspNetCore.Mvc;
using NetWebApi.Middlewares;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DelegateExampleController : Controller
    {
        [HttpGet("test")]
        public IActionResult Index()
        {
            string text = new DelegateExample().Format(
                "Este es un curso de programación en EscuelaIT",
                DelegateExample.SecondLetterUpperCase);
            return Ok(text);
        }
    }
}
