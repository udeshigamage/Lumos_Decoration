
namespace Deco_Sara.DTO
{
    public class CreateSubcategoryDTO
    {
       
        

        public string Subcategory_name { get; set; }

        public string Subcategory_description { get; set; }

        public string? Subcategory_image { get; set; }
        
        public int Category_Id { get; set; }
        
        

    }

    public class UpdatesubcategoryDTO : CreateSubcategoryDTO
    {
        
    }

    public class listSubcategoryDTO
    {
        public string Subcategory_name { get; set; }

        public int Subcategory_Id { get; set; }

    }
    public class ViewSubcategoryDTO
    {
        public string Subcategory_name { get; set; }

        public string Subcategory_description { get; set; }

        public string? Subcategory_image { get; set; }

        public int Subcategory_Id { get; set; }

        public int Category_Id { get; set; }

    }

   
}
