using NamyWork.Data.Entities;

namespace NamyWork.Core.Business
{
    public class CategoryModel : Model
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public CategoryModel()
        {

        }
        public CategoryModel(Category category)
        {
            this.Assign(category);
        }
    }
}