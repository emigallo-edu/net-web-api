using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Context;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private BaseCalculatorDbContext _context;

        public LoginController(BaseCalculatorDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<LoginModel> list = await this._context.Logins.ToListAsync();
            return Ok(list);
        }

        [HttpGet]
        [Route("today")]
        public ActionResult GetToday()
        {
            IQueryable<string> list = this._context.Logins
                .Where(x => x.Date.Date == DateTime.Today.Date && x.Name != "")
                .Select(x => x.Email);

            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(LoginModel model)
        {
            try
            {
                //List<LoginModel> demo = new List<LoginModel>();

                //LoginModel toRemove = demo.First(x => x.Id == model.Id);
                //LoginModel toRemove = demo.Where(x => x.Id == model.Id).First();
                //demo.Remove(toRemove);
                //this._context.Logins.FirstOrDefault(x => x.Id == 9999);
                //this._context.Logins.Skip(1).Take(3);

                //this._context.Remove(model);         
                //this._context.Remove(model);
                //await this._context.SaveChangesAsync();




                await this._context.AddAsync(model);
                if (await this._context.SaveChangesAsync() > 0)
                {
                    return Ok("El registro se guardó exitosamente");
                }

                return Ok("No se pudo guardar el registro");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}