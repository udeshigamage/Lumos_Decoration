using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Deco_Sara.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Product_Id { get; set; }

        public string Product_name { get; set; }

        public decimal Product_price { get; set; }

        public string? Product_image { get; set; }

        public decimal Product_discount { get; set; }


        [ForeignKey("Subcategory")]
        public int Subcategory_Id { get; set; }
        [ForeignKey("Category")]
        public int Category_Id { get; set; }
        [ValidateNever]
        public virtual  Subcategory Subcategory { get; set; }
        [ValidateNever]
        public virtual  Category Category { get; set; }

       public ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();


    }
}
