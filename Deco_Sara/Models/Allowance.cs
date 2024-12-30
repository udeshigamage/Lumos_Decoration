using System.ComponentModel.DataAnnotations;

namespace Deco_Sara.Models
{
    public class Allowance
    {
        // Properties instead of fields
        [Key]
        public int Allowance_ID { get; set; }  // Primary Key
        public DateTime Allowance_Date { get; set; }  // Property (PascalCase naming convention)
        public decimal Allowance_Amount { get; set; }  // Property
        public int Emp_ID { get; set; }  // Foreign Key
        public int Order_ID { get; set; }  // Foreign Key

        // Navigation property to Employee
        public Employee Employee { get; set; }
    }
}
