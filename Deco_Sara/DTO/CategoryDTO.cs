
namespace Deco_Sara.DTO
{
    public class CreateCategoryDTO
    {
       
       

        public string Category_name { get; set; }

        public string Category_description { get; set; }

        public string? Category_image { get; set; }
    }

    public class UpdateCategoryDTO:CreateCategoryDTO
    {
        public int Category_Id { get; set; }


        
    }
    public class ViewCategoryDTO
    {

        public int Category_Id { get; set; }

        public string Category_name { get; set; }

        public string Category_description { get; set; }

        public string? Category_image { get; set; }

        public string? Category_category { get; set; }
    }
}
