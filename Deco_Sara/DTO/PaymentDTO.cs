using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.DTO
{
    public class PaymentDTO
    {
        [Key]
        public int Payment_ID { get; set; }
        
        public string payment_method { get; set; }
        
        public DateTime payment_date { get; set; }
       
        public int Order_ID { get; set; }
        public decimal amount { get; set; } = 0.00M;

    }
}
