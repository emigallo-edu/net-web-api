using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("T_ORDERS")]
    public class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }

        public DateTime DeliveryDate { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}