namespace Model.Entities
{
    public class Standing
    {
        public Standing()
        {
            Clubs = new List<Club>();
        }

        public int Id { get; set; }
        public int TournamentId { get; set; }

        public Tournament Tournament { get; set; }
        public ICollection<Club> Clubs { get; set; }

        public void AddClub(Club club)
        {
            Clubs.Add(club);
        }
    }
}