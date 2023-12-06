using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Tournament
    {
        private Standing standing;
        private ICollection<Club> clubs;
        private ICollection<Match> matches;

        public Tournament()
        {
            this.standing = new Standing();
            this.clubs = new List<Club>();
            this.matches = new List<Match>();
        }

        public void Add(Club club)
        {
            this.clubs.Add(club);
        }

        public void Add(Match match)
        {
            this.matches.Add(match);
        }
    }
}