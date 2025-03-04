using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Deco_Sara.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Emp_ID { get; set; }

        public string emp_Name { get; set; }

        public string emp_address {  get; set; }

        public string email { get; set; }

        

        public string emp_contact_no { get; set; }

        public string? emp_image { get; set; }

        public string nic { get; set; }


        public decimal emp_allowance { get; set; } = 0.00M;

        

        [ForeignKey("role")]

        public int Role_ID { get; set; }

        [ValidateNever]
        public Role role { get; set; }
    }
}
