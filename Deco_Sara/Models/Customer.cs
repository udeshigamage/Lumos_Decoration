
using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.Models

{

    public class Customer
    {
        [Key]
        public int  Customer_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string contactno { get; set; }

        public string address { get; set; }
    }

  }

