using DanielsMoneyManagerApi.Models;
using Dapper;
using System.Data;

namespace DanielsMoneyManagerApi.Data
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly DapperContext _context;
        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories(int userId)
        {
            List<Category> categories = new List<Category>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);

                categories = connection.Query<Category>("Categories_Get", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            Category category = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Category_ID", categoryId);

                category = connection.QueryFirstOrDefault<Category>("Categories_Get_By_ID", parameters, commandType: CommandType.StoredProcedure);
            }

            return category;
        }

        public Category GetCategoryByName(int userId, string categoryName)
        {
            Category category = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("Category_Name", categoryName.Trim());

                category = connection.QueryFirstOrDefault<Category>("Categories_Get_By_Name", parameters, commandType: CommandType.StoredProcedure);
            }

            return category;
        }

        public Category InsertCategory(int userId, string categoryName)
        {
            Category category = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("Category_Name", categoryName.Trim());

                category = connection.QueryFirstOrDefault<Category>("Categories_Insert", parameters, commandType: CommandType.StoredProcedure);
            }

            return category;
        }

        public void UpdateCategory(int categoryId, string categoryName)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Category_Name", categoryName.Trim());
                parameters.Add("Category_ID", categoryId);

                connection.QueryFirstOrDefault<Category>("Categories_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCategory(int categoryId)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Category_ID", categoryId);

                connection.QueryFirstOrDefault<Category>("Categories_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
