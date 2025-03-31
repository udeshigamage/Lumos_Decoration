using Deco_Sara.DTO;
using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface ISubcategoryservice
    {
       


        Task<(IEnumerable<ViewSubcategoryDTO> subcategorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10, string searchterm = "");
        Task<List<ViewSubcategoryDTO>> GetByIdAsync(int id);
        Task<List<listSubcategoryDTO>> GetSubcatlist();
        Task<Message<string>> AddAsync(CreateSubcategoryDTO subcategory);

        Task<Message<string>> UpdateAsync(int id, UpdatesubcategoryDTO subcategory);

        Task<Message<string>> DeleteAsync(int id);

        Task<List<productlistDTO>> Listallproducts_subcatgeory(int id);

        Task<List<ViewSubcategoryDTO>> listallsubcategories(int id);




    }
}
