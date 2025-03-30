using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Deco_Sara.Models
{
    [Table("Tb_category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Category_Id { get; set; }

        public string Category_name { get; set; }

        public string Category_description { get; set; }

        public string? Category_image { get; set; }

        public DateTime Created_time { get; set; }

        public DateTime Modified_time { get; set; }

        public virtual ICollection<Subcategory> subcategories { get; set; }
    }

   
}
