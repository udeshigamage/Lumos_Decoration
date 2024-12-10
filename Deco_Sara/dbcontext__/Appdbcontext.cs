using Microsoft.EntityFrameworkCore;
using Deco_Sara.Models;

namespace Deco_Sara.dbcontext__
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
       
    }

    
   
}