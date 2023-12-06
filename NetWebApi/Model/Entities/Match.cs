using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Match
    {
        private Club localClub;
        private Club visitingClub;

        public Match()
        {

        }

        public void Add(Club localClub, Club visitingClub)
        {
            this.visitingClub = visitingClub;
            this.localClub = localClub;
        }

        public void Use(Stadium stadium)
        {

        }
    }
}