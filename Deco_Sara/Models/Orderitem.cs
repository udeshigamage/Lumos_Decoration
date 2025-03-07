using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deco_Sara.Models
{
    public class Orderitem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Orderitem_Id { get; set; }

        [ForeignKey("Order")]
        public int Order_ID { get; set; }
        [ForeignKey("Product")]
        public int Product_ID { get; set; }

        public  Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
