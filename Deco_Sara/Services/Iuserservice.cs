using Deco_Sara.DTO;

namespace Deco_Sara.Services
{
    public interface Iuserservice
    {
        Task<Message<string>> Createuserasync(CreateUserDTO createUser);

        Task<Message<string>> Updateuserasync(UpdateUserDTO updateUser, int userid);
        

        Task<Message<string>> Deleteuserasync(int User_ID);

        Task<ViewUserDTO> Getuserbyidasync(int User_ID);

        Task<(List<ViewUserDTO>, int Totalcount)> Getallusersasync(int page = 1, int pagesize = 5, string searchterm = "");
    }
}
