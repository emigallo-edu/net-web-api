using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubController : ControllerBase
    {
        private readonly ClubRepository _repository;

        public ClubController(DbContextOptions<ApplicationDbContext> options)
        {
            this._repository = new ClubRepository(options);
        }

        [HttpPost]
        public IActionResult Create(Club club)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this._repository.GetAll();
            return Ok(result);
        }
    }
}