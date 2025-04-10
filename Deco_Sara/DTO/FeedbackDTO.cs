using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.DTO
{
    public class CreateFeedbackDTO
    {
       
           
           public int Customer_ID { get; set; } // ID of the customer providing feedback
            public string FeedbackDescription { get; set; } 
            public int Rating { get; set; } 

        public string? fileurl { get; set; }
            

           


    }
}
