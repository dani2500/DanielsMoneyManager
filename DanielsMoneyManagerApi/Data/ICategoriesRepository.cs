using DanielsMoneyManagerApi.Models;

namespace DanielsMoneyManagerApi.Data
{
    public interface ICategoriesRepository
    {
        List<Category> GetCategories(int userId);
        Category GetCategoryByName(int userId, string name);
        Category GetCategoryById(int categoryId);
        Category InsertCategory(int userId, string categoryName);
        void UpdateCategory(int categoryId, string categoryName);
        void DeleteCategory(int categoryId);

    }
}
