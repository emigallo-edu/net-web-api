using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("calc")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public string Default()
        {
            return "Esta es la API de la calculadora.";
        }
    }
}