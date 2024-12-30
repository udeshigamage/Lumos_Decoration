using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string Name { get; set; }
       
        public string PasswordHash { get; set; }
        public int Role_ID { get; set; } 
    }
}
