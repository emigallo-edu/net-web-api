namespace Model.Entities
{
    public class Club
    {
        private ICollection<Player> players;

        public Club()
        {
            players = new List<Player>();
        }

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string City { get; set; }

        public void Add(Player player)
        {
            this.players.Add(player);
        }
    }
}