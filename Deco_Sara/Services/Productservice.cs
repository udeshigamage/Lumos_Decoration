using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;
using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Productservice:IProductservice
    {
        private readonly Appdbcontext _context;

        public Productservice(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ViewProductDTO> categorys, int TotalCount)> GetAllAsync(int page = 1, int pagesize = 10, string searchterm = "") {
            try
            {
                var query = _context.Products.AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchterm))
                {
                    query = query.Where(c => c.Product_name.Contains(searchterm) );
                }
                var totalcount = await query.CountAsync();
                var productset = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewProductDTO
                {
                   Product_discount = c.Product_discount,
                   Product_Id = c.Product_Id,
                   Product_image = c.Product_image,
                   Product_name = c.Product_name,
                   Product_price = c.Product_price,
                   Category_Id =c.Category_Id,
                   Subcategory_Id =c.Subcategory_Id
                   
                  

,
                }).ToListAsync();

                return (productset, totalcount);
            }
            catch (Exception ex)
            {
                throw new Exception("error fetching category");
            }
        }
        public async Task<List<ViewProductDTO>> GetByIdAsync(int id) {
            try
            {
                var product = await _context.Products.Where(c => c.Product_Id == id).Select(c => new ViewProductDTO
                {
                   Product_Id = c.Product_Id,
                   Product_name = c.Product_name,
                   Product_price = c.Product_price,
                   Product_discount = c.Product_discount,
                   Category_Id = c.Category_Id,
                   Subcategory_Id =c.Subcategory_Id,
                  
                   Product_image = c.Product_image,
                  


                }).ToListAsync();
                if (product == null)
                {
                    throw new Exception("product id not exist");
                }
                return (product);
            }
            catch
            {
                throw new Exception("error fetching product");
            }
        }


        public async Task<List<ProductlistallDTO>> Listallproducts(int id)
        {
            try
            {
                var products = await _context.Products.Where(c => c.Subcategory_Id == id).Select(c => new ProductlistallDTO
                {
                    Product_Id = c.Product_Id,
                    Product_name = c.Product_name,
                    Product_price = c.Product_price,
                    Product_discount = c.Product_discount,
                    Category_Id = c.Category_Id,
                    Subcategory_Id = c.Subcategory_Id,
                    Product_image = c.Product_image,
                    
                }).ToListAsync();

                return products;

            }
            catch
            {
                throw new Exception("error fetching product");
            }
        }
        public async Task<List<productlistDTO>> Getproductlist() {
            try
            {
                var producrlist = await _context.Products.Select(c => new productlistDTO
                {
                    Product_Id = c.Product_Id,
                    Product_name = c.Product_name,
                  
                }).ToListAsync();
               

                return (producrlist);

            }
            catch (Exception ex)
            {
                throw new Exception("error");

            }
        }
        public async Task<Message<string>> AddAsync(CreateProductDTO product) {
            try
            {

                bool isexist = await _context.Products.AnyAsync(c => c.Product_name == product.Product_name);
                if (isexist)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "product exist"
                    };
                }
                var product_ = new Product
                {
                   Product_name = product.Product_name,
                   Product_price = product.Product_price,
                   Product_image = product.Product_image,
                   Product_discount = product.Product_discount,
                   Category_Id = product.Category_Id,
                   Subcategory_Id = product.Subcategory_Id
                  

                };
              
                await _context.Products.AddAsync(product_);
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

     public async   Task<Message<string>> UpdateAsync(int id, UpdateProductDTO product) {

            try
            {
                var existingproduct = await _context.Products.FindAsync(id);
                if (existingproduct == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "Error"
                    };

                }
              existingproduct.Product_image = product.Product_image;
                existingproduct.Product_name = product.Product_name;
                existingproduct.Product_price = product.Product_price;
                existingproduct.Product_discount = product.Product_discount;
                existingproduct.Category_Id = product.Category_Id;
                existingproduct.Subcategory_Id = product.Subcategory_Id;
                

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

      public async   Task<Message<string>> DeleteAsync(int id)
        {

            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "product not found"
                    };




                }
                _context.Products.Remove(product);
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
    }
}
