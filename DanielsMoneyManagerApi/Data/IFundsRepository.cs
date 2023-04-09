using DanielsMoneyManagerApi.Models;

namespace DanielsMoneyManagerApi.Data
{
    public interface IFundsRepository
    {
        List<Fund> GetFunds(int userId);
        Fund GetFundById(int fundId);
        Fund GetFundByName(int userId, string fundName);
        void UpdateFund(int fundId, string fundName);
        Fund InsertFund(int userId, string fundName);
        void DeleteFund(int fundId);
    }
}
