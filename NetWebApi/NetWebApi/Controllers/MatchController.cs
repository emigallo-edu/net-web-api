using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using NetWebApi.Model;
using Repository;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchController : Controller
    {
        private readonly MatchRepository _matchRepository;
        private readonly StandingRepository _standingRepository;

        public MatchController(MatchRepository matchRepository, StandingRepository standingRepository)
        {
            this._matchRepository = matchRepository;
            this._standingRepository = standingRepository;
        }

        [HttpGet("{tournamentId}")]
        public async Task<IActionResult> GetAll([FromRoute] int tournamentId)
        {
            var result = await this._matchRepository.GetByTournamentsync(tournamentId);
            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMatch(RegisterMatchDTO item)
        {
            var matchResult = new MatchResult()
            {
                Matchid = item.Matchid,
                LocalClubGoals = item.LocalClubGoals,
                VisitingClubGoals = item.VisitingClubGoals
            };
            await this._matchRepository.InsertMatchResult(matchResult);

            Match match = await this._matchRepository.GetAsync(matchResult.Matchid);

            Standing localStandingClub = await this._standingRepository.GetAsync(item.StandingId, match.LocalClubId);
            Standing visitingStandingClub = await this._standingRepository.GetAsync(item.StandingId, match.VisitingClubId);

            switch (item.CalculateMatchResult())
            {
                case Model.MatchResultEnum.LocalClubWon:
                    localStandingClub.Win++;
                    visitingStandingClub.Loss++;
                    break;
                case Model.MatchResultEnum.VisitingClubWon:
                    localStandingClub.Loss++;
                    visitingStandingClub.Win++;
                    break;
                case Model.MatchResultEnum.Draw:
                    localStandingClub.Draw++;
                    visitingStandingClub.Draw++;
                    break;
                default:
                    break;
            }

            await this._standingRepository.UpdateAsync(localStandingClub);
            await this._standingRepository.UpdateAsync(visitingStandingClub);
            return Ok();
        }
    }
}