using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("T_PRODUCTS")]
    public class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; }
     
        public string Family { get; set; }
    }
}