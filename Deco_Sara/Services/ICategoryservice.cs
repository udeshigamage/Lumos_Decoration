using Deco_Sara.DTO;
using Deco_Sara.Models;

namespace Deco_Sara.Services
{
    public interface ICategoryservice
    {
        Task<(IEnumerable<ViewCategoryDTO> categorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10,string searchterm="");
        Task<List<ViewCategoryDTO>> GetByIdAsync(int id);
        Task<List<ListcategoryDTO>> Getcatlist();
        Task<Message<string>> AddAsync(CreateCategoryDTO category);

        Task<Message<string>> UpdateAsync(int id, UpdateCategoryDTO category);

        Task<Message<string>> DeleteAsync(int id);

        Task<List<listSubcategoryDTO>> Listallsubcategories_catgeory(int id);

        Task<List<Listcategoryall>> Listcatgeoryall();


        
    }
}
