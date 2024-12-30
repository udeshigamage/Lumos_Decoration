using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Deco_Sara.Models
{
    public class Notification
    {
        [Key]
        public int Notification_ID { get; set; }
        
        public string message { get; set; }

        public string actortype { get; set; }

        public DateTime timestamp { get; set; }

        public int User_ID { get; set; }

    }
}
