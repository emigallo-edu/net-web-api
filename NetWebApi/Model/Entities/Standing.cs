using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Standing
    {
        private ICollection<Club> clubs;

        public Standing()
        {
            clubs = new List<Club>();
        }

        public void AddClub(Club club)
        {
            clubs.Add(club);
        }
    }
}