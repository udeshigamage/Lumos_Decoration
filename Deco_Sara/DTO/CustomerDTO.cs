﻿


namespace Deco_Sara.DTO

{

    public class CustomerDTO
    {
        
        public int  Customer_ID { get; set; }
        public string Customer_name { get; set; }
        public string Customer_email { get; set; }

        public string Customer_contact_no { get; set; }

        public string Customer_address { get; set; }

        public  string Password { get; set; }


       public ICollection<OrderDTO>? Orders { get; set; }
        


    }

  }

