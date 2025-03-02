using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Deco_Sara.Models
{
    public class Subcategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Subcategory_Id { get; set; }

        public string Subcategory_name { get; set; }

        public string Subcategory_description { get; set; }

        public string? Subcategory_image { get; set; }
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

    }
}
