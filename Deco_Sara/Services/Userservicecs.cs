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

        public async Task<Message<string>> Createuserasync(CreateUserDTO createUser)
        {
            try
            {

                bool isexist = await _context.Users.AnyAsync(c => c.Email == createUser.Email);
                if (isexist)
                {
                    return new Message<string>
                    {
                        Status = "E",
                        Result = "You have already used this email to create account use another",
                        Text = "cannot create"
                    };
                }
                var user = new User
                {
                    Name = createUser.Name,
                    Email = createUser.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUser.PasswordHash),
                    usertype = createUser.usertype,
                    Address = createUser.Address,
                    Contact_no = createUser.Contact_no,
                    CreatedTime = DateTime.Now,

                };
                _context.Users.Add(user);
                _context.SaveChangesAsync();
                return new Message<string>
                {
                    Status = "S",

                    Text = "created succesfully"
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
                existinguser.usertype = updateUser.usertype;
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
                    usertype = c.usertype,
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
                    usertype = c.usertype,
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
