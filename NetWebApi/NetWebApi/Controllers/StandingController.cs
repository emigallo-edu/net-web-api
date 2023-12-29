using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.Model;
using Repository;
using System.Text;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StandingController : Controller
    {
        private readonly StandingRepository _standingRepository;

        public StandingController(StandingRepository standingRepository)
        {
            this._standingRepository = standingRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            List<StandingReportDTO> result = new List<StandingReportDTO>();

            foreach (Standing standing in await this._standingRepository.GetAsync(id))
            {
                result.Add(new StandingReportDTO(standing));
            }

            return Content(this.GetTable(result));
        }

        private string GetTable(List<StandingReportDTO> result)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<table>");

            builder.AppendLine("<tr>");
            builder.AppendLine("<th>Posicion</th>");
            builder.AppendLine("<th>Club</th>");
            builder.AppendLine("<th>Gano</th>");
            builder.AppendLine("<th>Perdio</th>");
            builder.AppendLine("<th>Empato</th>");
            builder.AppendLine("<th>Jugados</th>");
            builder.AppendLine("<th>Puntaje</th>");
            builder.AppendLine($"</tr>");

            foreach (StandingReportDTO standing in result)
            {
                builder.AppendLine("<tr>");
                builder.AppendLine($"<td>{standing.Position}</td>");
                builder.AppendLine($"<td>{standing.ClubName}</td>");
                builder.AppendLine($"<td>{standing.Win}</td>");
                builder.AppendLine($"<td>{standing.Loss}</td>");
                builder.AppendLine($"<td>{standing.Draw}</td>");
                builder.AppendLine($"<td>{standing.MatchsPlayed}</td>");
                builder.AppendLine($"<td>{standing.Scoring}</td>");
                builder.AppendLine($"</tr>");
            }

            return builder.ToString();
        }
    }
}