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


        public List<CategoryBalance> GetBalances(int userId, DateTime toTime)
        {
            List<CategoryBalance> balances = new List<CategoryBalance>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("To_Time", toTime);


                balances = connection.Query<CategoryBalance>("Categories_Get_Balances", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return balances;
        }

        public List<CategoryBalanceHistoryUnit> GetBalanceHistory(int userId, int maxTimeBackMonths)
        {
            List<CategoryBalanceHistoryUnit> balances = new List<CategoryBalanceHistoryUnit>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("Max_Time_Back_Months", maxTimeBackMonths);


                balances = connection.Query<CategoryBalanceHistoryUnit>("Categories_Get_Balances_History", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return balances;
        }

        public TotalBalance GetTotalBalance(int userId, DateTime toTime)
        {
            TotalBalance totalBalance = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("To_Time", toTime);

                totalBalance = connection.QueryFirstOrDefault<TotalBalance>("Categories_Get_Total_Balance", parameters, commandType: CommandType.StoredProcedure);
            }

            return totalBalance;
        }

    }
}
