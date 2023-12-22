using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Entities;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[AuditResponseFilter]
    public class ClubController : ControllerBase
    {
        private readonly IClubRepository _repository;

        public ClubController(IClubRepository repository)
        {
            this._repository = repository;
        }

        [HttpPost]
        public IActionResult Create(Club club)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._repository.GetAllAsync();

            foreach (var item in result.Where(x => x.Stadium != null))
            {
                item.Stadium.Club = null;
            }

            return Ok(result);
        }

        [HttpGet("short")]
        public async Task<IActionResult> GetAllShort()
        {
            var result = await this._repository.GetAllShortAsync();
            return Ok(result);
        }
    }
}