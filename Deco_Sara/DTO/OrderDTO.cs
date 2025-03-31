using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deco_Sara.DTO
{
  
    
    public class OrderDTO
    {
        public int Order_ID { get; set; }
        public string Order_description { get; set; }

        public DateTime Order_deadlinedate { get; set; }


        public decimal Order_allowance { get; set; }

        public bool Order_payment_status { get; set; }

        public bool Order_allowance_status { get; set; }

        public string Order_status { get; set; }

        public decimal TotalCost { get; set; }
    }

    public class OrderCreateDTO
    {
        
        public string Order_description { get; set; }

        public DateTime Order_deadlinedate { get; set; }


        public decimal Order_allowance { get; set; }

        public bool Order_payment_status { get; set; }

        public bool Order_allowance_status { get; set; }

        public string Order_status { get; set; }

        public decimal TotalCost { get; set; }
    }
    public class Orderrequest
    {
        public int Customer_ID { get; set; }
        public List<OrderitemDTO> orderitems { get; set; } = new List<OrderitemDTO>();
        public OrderDTO order { get; set; }

    }
}
