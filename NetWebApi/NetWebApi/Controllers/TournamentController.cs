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
        private readonly MatchRepository _matchRepository;

        public TournamentController(TournamentRepository repository, IClubRepository clubRepository, MatchRepository matchRepository)
        {
            this._tournamentRepository = repository;
            this._clubRepository = clubRepository;
            this._matchRepository = matchRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            List<Club> clubs = await this._clubRepository.GetAllAsync();
            clubs = clubs.Take(4).ToList();
            List<Match> matches = this.GetDayMatchs(clubs);

            List<Standing> standings = new List<Standing>();
            int standingId = 1;
            foreach (Club club in clubs)
            {
                standings.Add(new Standing()
                {
                    Id = standingId,
                    ClubId = club.Id
                });
                standingId++;
            }

            var tournament = new Tournament()
            {
                Start = matches.Min(x => x.Date),
                End = matches.Max(x => x.Date),
                Standings = standings,
                Matches = matches
            };

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