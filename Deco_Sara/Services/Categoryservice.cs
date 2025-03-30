using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;
using Deco_Sara.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Categoriesservice:ICategoryservice
    {
        private readonly Appdbcontext _context;

        public Categoriesservice(Appdbcontext context)
        {
            _context = context;
        }

        
        


        public async Task<(IEnumerable<ViewCategoryDTO> categorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10, string searchterm = "")
        {
            try
            {
                var query = _context.Categories.AsQueryable();
                if(!string.IsNullOrWhiteSpace(searchterm))
                {
                    query = query.Where(c => c.Category_name.Contains(searchterm) || c.Category_description.Contains(searchterm));
                }
                var totalcount = await query.CountAsync();
                var categoryset = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewCategoryDTO
                {
                    Category_name = c.Category_name,
                    Category_description = c.Category_description,
                    Category_Id = c.Category_Id,
                    Category_image = c.Category_image

,
                }).ToListAsync();

                return (categoryset, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }

        }
       public async Task<List<ViewCategoryDTO>> GetByIdAsync(int id) {
            try
            {
                var category = await _context.Categories.Where(c=> c.Category_Id  == id).Select(c => new ViewCategoryDTO
                {
                    Category_description =c.Category_description,
                    Category_name = c.Category_name,
                    Category_Id = c.Category_Id,
                    Category_image = c.Category_image


                }).ToListAsync();
                if(category == null)
                {
                    throw new Exception("category id not exist");
                }
                return (category);
            }
            catch
            {
                throw new Exception("error fetching category");
            }
        }
        public async Task<List<ListcategoryDTO>> Getcatlist() {
         try
            {
                var categorylist = await _context.Categories.Select(c => new ListcategoryDTO
                {
                    Category_Id = c.Category_Id,
                    Category_name = c.Category_name,
                }).ToListAsync();

                return (categorylist);

            }
            catch(Exception ex)
            {
                throw new Exception("error");

            }
        }
       public async Task<Message<string>> AddAsync(CreateCategoryDTO category) {
            try
            {

                bool isexist =  await _context.Categories.AnyAsync(c => c.Category_name == category.Category_name);
                if (isexist)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Category exist"
                    };
                }
                var category_ = new Category
                {
                    Category_name= category.Category_name,
                    Category_description =category.Category_description,
                    Category_image = category.Category_image,
                    Created_time = DateTime.Now
                    
                    


                };
               await _context.Categories.AddAsync(category_);
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

        public async Task<Message<string>> UpdateAsync(int id, UpdateCategoryDTO category) {
            try
            {
                var existingcategory = await _context.Categories.FindAsync(id);
                if (existingcategory == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
                existingcategory.Category_image = category.Category_image;
                existingcategory.Category_name = category.Category_name;
                existingcategory.Category_description = category.Category_description;
                existingcategory.Modified_time = DateTime.Now;

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

      public async  Task<Message<string>> DeleteAsync(int id) {
            try
            {
                var category = _context.Categories.Find(id);
                if (category == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Category not found"
                    };




                }
                _context.Categories.Remove(category);
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

     public async   Task<List<listSubcategoryDTO>> Listallsubcategories_catgeory(int id)
        {
            try
            {
                var subcategories = _context.Categories
                            .Where(c => c.Category_Id == id)
                            .SelectMany(c => c.subcategories).Select(c => new listSubcategoryDTO
                            {
                                Subcategory_name=c.Subcategory_name,
                                Subcategory_Id=c.Subcategory_Id,
                                
                            })
                            .ToList();
                return subcategories;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
