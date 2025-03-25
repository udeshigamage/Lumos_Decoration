using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Deco_Sara.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_Id { get; set; }

        public string Category_name { get; set; }

        public string Category_description { get; set; }

        public string? Category_image { get; set; }

        public ICollection<Subcategory> subcategories { get; set; }
    }

   
}
