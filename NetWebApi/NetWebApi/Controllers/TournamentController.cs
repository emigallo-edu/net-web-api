using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Entities;
using NetWebApi.Utils;
using Repository;

namespace NetWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : Controller
    {
        private readonly TournamentRepository _tournamentRepository;
        private readonly IClubRepository _clubRepository;
        private readonly StandingRepository _standingRepository;

        public TournamentController(TournamentRepository repository, IClubRepository clubRepository, StandingRepository standingRepository)
        {
            this._tournamentRepository = repository;
            this._clubRepository = clubRepository;
            this._standingRepository = standingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            List<Club> clubs = await this._clubRepository.GetAllAsync();
            clubs = clubs.Take(4).ToList();
            List<Match> matches = this.GetDayMatchs(clubs);

            var tournament = new Tournament()
            {
                Start = matches.Min(x => x.Date),
                Standings = new List<Standing>(),
                Matches = matches,
                End = matches.Max(x => x.Date)
            };

            foreach (Club club in clubs)
            {
                tournament.Standings.Add(new Standing()
                {
                    Tournament = tournament,
                    ClubId = club.Id
                });
            }

            await this._tournamentRepository.InsertAsync(tournament);
            return Ok();
        }

        private List<Match> GetDayMatchs(List<Club> clubs)
        {
            List<Match> matches = new List<Match>();

            DateTime matchDay1 = DateTime.Now;
            DateTime matchDay2 = DateTime.Now.AddDays(7);
            DateTime matchDay3 = DateTime.Now.AddDays(14);

            matches.Add(new Match()
            {
                LocalClubId = clubs.First().Id,
                VisitingClubId = clubs.Second().Id,
                Date = matchDay1
            });

            matches.Add(new Match()
            {
                LocalClubId = clubs.Third().Id,
                VisitingClubId = clubs.Fourth().Id,
                Date = matchDay1
            });

            matches.Add(new Match()
            {
                LocalClubId = clubs.First().Id,
                VisitingClubId = clubs.Third().Id,
                Date = matchDay2
            });

            matches.Add(new Match()
            {
                LocalClubId = clubs.Second().Id,
                VisitingClubId = clubs.Fourth().Id,
                Date = matchDay2
            });

            matches.Add(new Match()
            {
                LocalClubId = clubs.First().Id,
                VisitingClubId = clubs.Fourth().Id,
                Date = matchDay3
            });

            matches.Add(new Match()
            {
                LocalClubId = clubs.Second().Id,
                VisitingClubId = clubs.Third().Id,
                Date = matchDay3
            });

            return matches;
        }
    }
}