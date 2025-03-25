
namespace Deco_Sara.DTO
{
    public class OrderitemDTO
    {
        
        public int Orderitem_Id { get; set; }

        public decimal quantity {get; set; }

        
        public int? Order_ID { get; set; }
       
        public int Product_ID { get; set; }

        public virtual OrderDTO Order { get; set; }

        public virtual ProductDTO Product { get; set; }
    }
}
