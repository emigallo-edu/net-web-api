using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Table("T_ORDER_ITEMS")]
    public class OrderItem
    {
        [Column("Order_Id")]
        public int OrderId { get; set; }

        public int Id { get; set; }

        [Column("Product_Id")]
        public int ProductId { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}