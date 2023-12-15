using Microsoft.AspNetCore.Mvc;
using Model.Entities;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(Club club)
        {
            return Ok();
        }
    }
}