using DanielsMoneyManagerApi.Models;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DanielsMoneyManagerApi.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            User user;
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserID", id);

                user = connection.QuerySingleOrDefault<User>("Users_Get_By_ID", parameters, commandType: CommandType.StoredProcedure);
            }

            return user;
        }

        public User GetUserByEmail(string email)
        {
            User user;
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserEmail", email);

                user = connection.QuerySingleOrDefault<User>("Users_Get_By_Email", parameters, commandType: CommandType.StoredProcedure);
            }

            return user;
        }

        public User InsertUser(string userName, string userPassword, string userEmail)
        {
            User user;
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", userName);
                parameters.Add("UserPassword", userPassword);
                parameters.Add("UserEmail", userEmail);


                user = connection.QuerySingleOrDefault<User>("Users_Insert", parameters, commandType: CommandType.StoredProcedure);
            }

            return user;
        }

        public User GetUserByCategoryId(int categoryId)
        {
            User user;
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Category_ID", categoryId);

                user = connection.QuerySingleOrDefault<User>("Users_Get_By_Category_ID", parameters, commandType: CommandType.StoredProcedure);
            }

            return user;
        }

        public User GetUserByFundId(int fundId)
        {
            User user;
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Fund_ID", fundId);

                user = connection.QuerySingleOrDefault<User>("Users_Get_By_Fund_ID", parameters, commandType: CommandType.StoredProcedure);
            }

            return user;
        }
    }
}
