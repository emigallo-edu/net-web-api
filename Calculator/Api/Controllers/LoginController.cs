using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Context;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private IApiContext _db;

        public LoginController()
        {
            this._db = ApiContext.Instance;
        }

        [HttpPost]
        public async Task<ActionResult> Create(string name, string email)
        {
            LoginModel model = new LoginModel()
            {
                Name = name,
                Email = email,
                Date = DateTime.Now
            };

            await this._db.Logins.AddAsync(model);
            return Ok("El registro se insertó correctamente");
        }

        [HttpGet]
        public ActionResult Get()
        {
            List<LoginModel> list = this._db.Logins.ToList();
            return Ok(list);
        }
    }
}