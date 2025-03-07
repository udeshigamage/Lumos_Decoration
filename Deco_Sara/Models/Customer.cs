
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deco_Sara.Models

{

    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Customer_ID { get; set; }
        public string Customer_name { get; set; }
        public string Customer_email { get; set; }

        public string Customer_contact_no { get; set; }

        public string Customer_address { get; set; }

        public  string Password { get; set; }


       public ICollection<Order> Orders { get; set; }
        

    }

  }

