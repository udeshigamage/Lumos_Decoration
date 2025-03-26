
namespace Deco_Sara.DTO
{
    public class ProductDTO
    {

       

        public int Product_Id { get; set; }

        public string Product_name { get; set; }

        public decimal Product_price { get; set; }

        public string? Product_image { get; set; }

        public decimal Product_discount { get; set; }


        
        public int Subcategory_Id { get; set; }
      
        public int Category_Id { get; set; }
        
       

       public ICollection<OrderitemDTO> Orderitems { get; set; } = new List<OrderitemDTO>();


    }
}
