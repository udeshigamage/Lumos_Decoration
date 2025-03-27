

using Deco_Sara.Models;

namespace Deco_Sara.DTO

{
    public class CreateUserDTO
    {
       
       
        public string Name { get; set; }
       
        public string PasswordHash { get; set; }
        public usertype Role { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }

        public string Contact_no { get; set; }

        
    }
    public class UpdateUserDTO:CreateUserDTO
    {
        public int User_ID { get; set; }

    }

    public class ViewUserDTO
    {
        public int User_ID { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public usertype Role { get; set; }
        public string Email { get; set; }

        public string Contact_no { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime LastUpdatedTime { get; set; }
    }

    public class LoginDTO
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

    }
}
