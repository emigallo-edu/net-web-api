using Model.Entities;

namespace NetWebApi.Model
{
    public class StandingReportDTO
    {
        public StandingReportDTO(Standing standing)
        {
            this.ClubName = standing.Club.Name;
            this.Win = standing.Win;
            this.Draw = standing.Draw;
            this.Loss = standing.Loss;
        }

        public string ClubName { get; init; }
        public int Win { get; init; }
        public int Draw { get; init; }
        public int Loss { get; init; }

        public int Scoring { get => this.Win * 3 + this.Draw; }
        public int Position { get; set; }
        public int MatchsPlayed { get => this.Win + this.Draw + this.Loss; }
    }
}