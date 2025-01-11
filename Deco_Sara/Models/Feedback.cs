using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int FeedbackId { get; set; } // Unique ID for the feedback
            public int Customer_ID { get; set; } // ID of the customer providing feedback
            public string FeedbackDescription { get; set; } // The feedback text from the customer
            public int Rating { get; set; } // Rating given by the customer (e.g., 1-5 scale)
            public DateTime FeedbackDate { get; set; } // Date the feedback was submitted
            public string FeedbackCategory { get; set; } // Optional: Category (e.g., service, product, delivery)
            public bool IsResolved { get; set; } // Flag to indicate if the feedback has been addressed
       

    }
}
