using DanielsMoneyManagerApi.Models;
using System;

namespace DanielsMoneyManagerApi.Data
{
    public interface IFundsRepository
    {
        List<Fund> GetFunds(int userId);
        List<FundStatus> GetFundsStatus(int userId, DateTime toTime);
        List<FundStatusHistoryUnit> GetFundsStatusHistory(int userId, int maxTimeBackMonths);
        FundsStatusTotal GetFundsStatusTotal(int userId, DateTime toTime);
        Fund GetFundById(int fundId);
        Fund GetFundByName(int userId, string fundName);
        void UpdateFund(int fundId, string fundName);
        Fund InsertFund(int userId, string fundName);
        void DeleteFund(int fundId);
    }
}
