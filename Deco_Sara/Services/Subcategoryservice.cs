using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;
using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Subcategoryservice : ISubcategoryservice
    {
        private readonly Appdbcontext _context;

        public Subcategoryservice(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ViewSubcategoryDTO> subcategorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10, string searchterm = "")
        {
            try
            {
                var query = _context.Subcategories.AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchterm))
                {
                    query = query.Where(c => c.Subcategory_name.Contains(searchterm) || c.Subcategory_description.Contains(searchterm));
                }
                var totalcount = await query.CountAsync();
                var subcategoryset = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewSubcategoryDTO
                {
                    Subcategory_description = c.Subcategory_description,
                    Subcategory_name = c.Subcategory_name,
                    Subcategory_Id = c.Subcategory_Id,
                    Subcategory_image = c.Subcategory_image,
                    Category_Id = c.Category_Id



,
                }).ToListAsync();

                return (subcategoryset, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
        }
        public async Task<List<ViewSubcategoryDTO>> GetByIdAsync(int id) {
            try
            {
                var subcategory = await _context.Subcategories.Where(c => c.Subcategory_Id == id).Select(c => new ViewSubcategoryDTO
                {
                    Subcategory_description = c.Subcategory_description,
                    Subcategory_name = c.Subcategory_name,
                    Subcategory_Id = c.Subcategory_Id,
                    Subcategory_image = c.Subcategory_image,
                    Category_Id = c.Category_Id


                }).ToListAsync();
              
                if (subcategory == null)
                {
                    throw new Exception("subcategory id not exist");
                }
                return (subcategory);
            }
            catch
            {
                throw new Exception("error fetching subcategory");
            }
        }
        public async Task<List<listSubcategoryDTO>> GetSubcatlist() {
            try
            {
                var categorylist = await _context.Subcategories.Select(c => new listSubcategoryDTO
                {
                   Subcategory_name = c.Subcategory_name,
                   Subcategory_Id = c.Subcategory_Id,
                }).ToListAsync();

                return (categorylist);

            }
            catch (Exception ex)
            {
                throw new Exception("error");

            }
        }
        public async Task<Message<string>> AddAsync(CreateSubcategoryDTO subcategory) {
            try
            {

                bool isexist = await _context.Subcategories.AnyAsync(c => c.Subcategory_name == subcategory.Subcategory_name);
                if (isexist)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "subCategory exist"
                    };
                }
                var subcategory_ = new Subcategory
                {
                   Subcategory_name = subcategory.Subcategory_name,
                   Subcategory_description = subcategory.Subcategory_description,
                   Subcategory_image = subcategory.Subcategory_image,
                   Category_Id = subcategory.Category_Id,





                };
                await _context.Subcategories.AddAsync(subcategory_);
                await _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully created"
                };

            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = "Error"
                };

            }
        }

        public async Task<Message<string>> UpdateAsync(int id, UpdatesubcategoryDTO subcategory) {
            try
            {
                var existingcategory = await _context.Subcategories.FindAsync(id);
                if (existingcategory == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
               existingcategory.Subcategory_image = subcategory.Subcategory_image;
                existingcategory.Subcategory_name = subcategory.Subcategory_name;
                existingcategory.Subcategory_description = subcategory.Subcategory_description;
                existingcategory.Category_Id = subcategory.Category_Id;

                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully updated"
                };


            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = "Error"
                };

            }
        }

        public async Task<Message<string>> DeleteAsync(int id) {


            try
            {
                var subcategory = _context.Subcategories.Find(id);
                if (subcategory == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Category not found"
                    };




                }
                _context.Subcategories.Remove(subcategory);
                _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",
                    Result = "Successfully deleted"
                };

            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = "Error"
                };
            }
        }

        public async Task<List<productlistDTO>> Listallproducts_subcatgeory(int id) {
            try
            {
                var products = _context.Subcategories
                            .Where(c => c.Subcategory_Id == id)
                            .SelectMany(c => c.Products).Select(c => new productlistDTO
                            {
                               Product_Id = c.Product_Id,
                               Product_name = c.Product_name,

                            })
                            .ToList();
                return products ;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }  
}
