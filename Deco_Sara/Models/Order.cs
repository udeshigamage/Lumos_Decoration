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
        public decimal TotalCost { get; set; }

        // Foreign Key for Customer
        [ForeignKey("Customer")]
        [Required]
        public int Customer_ID { get; set; }
        public virtual User Customer { get; set; }

        // Foreign Key for Employee (nullable until assigned)
        [ForeignKey("Employee")]
        public int? Employee_ID { get; set; }
        public virtual User? Employee { get; set; }

        public ICollection<Orderitem> Orderitems { get; set; }
    }
    public class OrderitemDTO
    {
        public int Product_ID { get; set; }
        public decimal quantity { get; set; }
    }
    public class OrderDTO
    {
        public int Order_ID { get; set; }
        public string Order_description { get; set; }
        public DateTime Order_deadlinedate { get; set; }
        public int Customer_ID { get; set; } // Always required
        public int? Employee_ID { get; set; } // Nullable until assigned
        public decimal Order_allowance { get; set; }
        public bool Order_payment_status { get; set; }
        public bool Order_allowance_status { get; set; }
        public string Order_status { get; set; }
        public decimal TotalCost { get; set; }
    }
    public class Orderrequest
    {
        public int User_ID { get; set; }
        public List<OrderitemDTO> orderitems { get; set; } = new List<OrderitemDTO>();
        public CreateOrderDTO order { get; set; }

    }

    public class CreateOrderDTO
    {
        public string Order_description { get; set; }
        public DateTime Order_deadlinedate { get; set; }
        public int Customer_ID { get; set; } // Required for new orders
        public decimal Order_allowance { get; set; }
        public bool Order_payment_status { get; set; }
        public bool Order_allowance_status { get; set; }
        public string Order_status { get; set; }
        public decimal TotalCost { get; set; }
    }

}

