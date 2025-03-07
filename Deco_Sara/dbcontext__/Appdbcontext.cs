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
        //public DbSet<Order> Order { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Role> role { get; set; }

        public DbSet<Employee>Employee {  get; set; }
        public DbSet<Notification> notifications { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }

        //public DbSet<Product> Products { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Orderitem> OrderItems { get; set; }





    }


    
   
}