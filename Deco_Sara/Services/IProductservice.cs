using Deco_Sara.DTO;
using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface IProductservice
    {

        Task<(IEnumerable<ViewProductDTO> categorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10, string searchterm = "");
        Task<List<ViewProductDTO>> GetByIdAsync(int id);
        Task<List<productlistDTO>> Getproductlist();
        Task<Message<string>> AddAsync(CreateProductDTO product);

        Task<Message<string>> UpdateAsync(int id, UpdateProductDTO product);

        Task<Message<string>> DeleteAsync(int id);

        Task<List<ProductlistallDTO>> Listallproducts(int id);




    }
}
