using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deco_Sara.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }

        

        public DateTime Order_date { get; set; }

        public string Order_description { get; set; }

        public DateTime Order_deadlinedate { get; set; }

        
        public decimal Order_allowance { get; set; }

        public bool Order_payment_status { get; set; }

        public bool Order_allowance_status { get; set; }

        public string Order_status { get; set; }
        [ForeignKey("Customer")]
        public int Customer_ID { get; set; }

        public virtual Customer Customer { get; set; }
        
        public decimal TotalCost { get; set; }

        public ICollection<Orderitem> Orderitems { get; set; }

       
    }

  
}
