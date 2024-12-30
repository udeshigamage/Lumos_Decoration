using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.Models
{
    public class Role
    {
        [Key]
        public int Roll_ID { get; set; }
       
        public string Roll_Name { get; set; }
        
        public string Roll_Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
