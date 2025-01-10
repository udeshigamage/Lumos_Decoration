using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deco_Sara.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }

        public string EventType { get; set; }

        public DateTime order_date { get; set; }

        public string orderdescription { get; set; }

        public DateTime deadlinedate { get; set; }

        public string location { get; set; }
        
        public string status { get; set; }
        
        public int Customer_ID { get; set; }
        
        public decimal TotalCost { get; set; }

       
    }

  
}
