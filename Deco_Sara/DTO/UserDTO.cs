

using Deco_Sara.Models;

namespace Deco_Sara.DTO

{
    public class CreateUserDTO
    {


        public string Name { get; set; }

        public string Email { get; set; }

        public string Contact_no { get; set; }

        public string Address { get; set; }

        public string PasswordHash { get; set; }
        public usertype Role { get; set; }

        public string RoleName { get; set; }

        public string? userimage { get; set; }

        public string? NIC { get; set; }


        public string? Servicerole { get; set; }

        public bool isactive { get; set; }


    }
    public class UpdateUserDTO:CreateUserDTO
    {
        

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

        public string RoleName { get; set; }

        public string? userimage { get; set; }

        public string? NIC { get; set; }


        public string? Servicerole { get; set; }
        public bool isactive { get; set; }
    }

    public class LoginDTO
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

    }

    public class ListuserDTO
    {
       public  int User_ID { get; set; }
       public string Name { get; set; }

    }
}
