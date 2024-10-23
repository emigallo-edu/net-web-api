using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("T_CUSTOMERS")]
    public class Customer
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }

        public string Address { get; set; }
        
        public string City { get; set; }
    }
}