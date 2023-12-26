using Microsoft.AspNetCore.Mvc;
using Repository;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResponseAuditController : Controller
    {
        private readonly ResponseAuditRepository _responseAuditRepository;

        public ResponseAuditController(ResponseAuditRepository repository)
        {
            this._responseAuditRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this._responseAuditRepository.GetAllAsync();
            return Ok(result);
        }
    }
}