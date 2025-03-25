using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel.DataAnnotations.Schema;
namespace Deco_Sara.DTO
{
    public class CreateEmployeeDTO
    {
        
        public int Emp_ID { get; set; }

        public string emp_Name { get; set; }

        public string emp_address {  get; set; }

        public string email { get; set; }

        

        public string emp_contact_no { get; set; }

        public string? emp_image { get; set; }

        public string nic { get; set; }


        public decimal emp_allowance { get; set; } = 0.00M;

        

        

        public int Role_ID { get; set; }

        
        public RoleDTO role { get; set; }
    }

   
}
