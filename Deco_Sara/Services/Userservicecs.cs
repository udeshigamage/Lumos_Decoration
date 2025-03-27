using Deco_Sara.dbcontext__;
using Deco_Sara.DTO;
using Deco_Sara.Models;
using Microsoft.EntityFrameworkCore;

namespace Deco_Sara.Services
{
    public class Userservicecs : Iuserservice
    {
        private readonly Appdbcontext _context;

        public Userservicecs(Appdbcontext context)
        {
            _context = context;
        }

        public async Task<Message<string>> Createuserasync(CreateUserDTO User)
        {
            try
            {

                if (User == null)
                {

                    return new Message<string>
                    {
                        Status = "E",
                        Text = "Data is empty"
                    };

                }

                bool existemail = await _context.Users.AnyAsync(u => u.Email == User.Email);

                if (existemail)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Text = $"{User.Email} already exist"
                    };
                }

                var user = new User
                {
                    Email = User.Email,
                    Name = User.Name,
                    Contact_no = User.Contact_no,
                    CreatedTime = DateTime.UtcNow,
                    Address = User.Address,
                    Role = User.Role,

                    


                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(User.PasswordHash)


                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",
                    Text = "User created successfully",
                };


            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Text = ex.Message,
                };
            }

        }

        public async Task<Message<string>> Updateuserasync(UpdateUserDTO updateUser, int userid)
        {

            try
            {
                var existinguser = await _context.Users.FindAsync(userid);
                if (existinguser == null)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "not found",
                        Text = "cannot update"
                    };
                }
                existinguser.Name = updateUser.Name;
                existinguser.Email = updateUser.Email;
                existinguser.PasswordHash = updateUser.PasswordHash;
                existinguser.Role = updateUser.Role;
                existinguser.Address = updateUser.Address;
                existinguser.Contact_no = updateUser.Contact_no;
                existinguser.LastUpdatedTime = DateTime.Now;
                _context.SaveChangesAsync();

                return new Message<string>
                {
                    Status = "S",

                    Text = "updated succesfully"
                };
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message,
                    Text = "cannot create"
                };

            }
        }

        public async Task<Message<string>> Deleteuserasync(int User_ID)
        {

            try
            {
                var user = await _context.Users.FindAsync(User_ID);

                if (user == null)
                {
                    return new Message<string>
                    {
                        Result = "Not found",
                        Status = "E",


                    };
                }
                _context.Users.Remove(user);
                _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",

                    Text = "deleted succesfully"
                };
            }
            catch (Exception ex)
            {
                return new Message<string>
                {
                    Status = "E",
                    Result = ex.Message,
                    Text = "cannot create"
                };

            }
        }

        public async Task<(List<ViewUserDTO>, int Totalcount)> Getallusersasync(int page = 1, int pagesize = 5, string searchterm = "")
        {

            try
            {
                var query = _context.Users.AsQueryable();
                if (!string.IsNullOrWhiteSpace(searchterm))
                {
                    query = query.Where(v => v.Name.Contains(searchterm) || v.Email.Contains(searchterm) || v.Contact_no.Contains(searchterm));
                }
                var totalcount = query.Count();
                var users = await query.Skip((page - 1) * pagesize).Take(pagesize).Select(c => new ViewUserDTO
                {
                    Name = c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Contact_no = c.Contact_no,
                    Role = c.Role,
                    CreatedTime = c.CreatedTime,
                    LastUpdatedTime = c.LastUpdatedTime,
                    User_ID = c.User_ID


                }).ToListAsync();
                return (users, totalcount);



            }
            catch (Exception ex)
            {
                throw new Exception("error");

            }
        }

        public async Task<ViewUserDTO> Getuserbyidasync(int User_ID)
        {
            try
            {
                var users = _context.Users.Where(c=> c.User_ID == User_ID).Select(c => new ViewUserDTO
                {
                    Name= c.Name,
                    Email = c.Email,
                    Address = c.Address,
                    Contact_no = c.Contact_no,
                    Role = c.Role,
                    CreatedTime = c.CreatedTime,
                    LastUpdatedTime = c.LastUpdatedTime,
                    User_ID = c.User_ID

                }).FirstOrDefault();
                return users;
                if (users == null)
                {
                    throw new Exception("not found");
                }
              

            }
            catch (Exception ex)
            {

                throw new Exception("error");
            };


        }
    }
}
