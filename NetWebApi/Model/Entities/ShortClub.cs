using System.ComponentModel.DataAnnotations;

namespace Model.Entities
{
    public class ShortClub
    {

        public string City { get; set; }
        public string Phone { get; set; }
        public string? Address { get; set; }
        public int Capacity { get; set; }
    }
}