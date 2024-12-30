using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.Models
{
    public class Employee
    {
        [Key]
        public int Emp_ID { get; set; }

        public string emp_Name { get; set; }

        public string emp_Role { get; set; }

        public string emp_contact_no { get; set; }

        public decimal Allowance { get; set; } = 0.00M;
    }
}
