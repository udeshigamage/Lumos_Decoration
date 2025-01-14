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

        public DbSet<Customer> Customer { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Allowance> Allowances { get; set; }
        public DbSet<Decorationstatus>Decorationstatuses { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
        

        public DbSet<Employee>Employee {  get; set; }
        public DbSet<Notification> notifications { get; set; }



    }


    
   
}