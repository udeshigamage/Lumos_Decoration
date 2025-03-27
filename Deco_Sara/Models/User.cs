using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deco_Sara.Models
    
{
    [Table("Tb_Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_ID { get; set; }
        public string Name { get; set; }

        public string Email    { get; set; }

        public string Contact_no { get; set; }

        public string Address { get; set; }
       
        public string PasswordHash { get; set; }
        public usertype Role { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastUpdatedTime { get; set; }
    }

    public enum usertype
    {
        Admin,
        Customer,
        Employee
    }
}
