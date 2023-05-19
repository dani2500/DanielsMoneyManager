using DanielsMoneyManagerApi.Models;

namespace DanielsMoneyManagerApi.Data
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        User GetUserByEmail(string email);
        User InsertUser(string userName, string userPassword, string userEmail);
        User GetUserByCategoryId(int categoryId);
        User GetUserByFundId(int fundId);
    }
}
