using DanielsMoneyManagerApi.Models;

namespace DanielsMoneyManagerApi.Data
{
    public interface ICashActionsRepository
    {
        List<CashAction> GetCashActions(DateTime fromTime, DateTime toTime, int categoryId, int userId);
        List<CategoryBalance> GetBalances(int userId, DateTime toTime);
        TotalBalance GetTotalBalance(int userId, DateTime toTime);
        CashAction InsertCashActions(int categoryId, string description, float sum, DateTime cashActionTime);
        void DeleteCashActions(string cashActionIds, int userId);
        void UpdateCashActions(int cashActionId, int categoryId, string description, float sum, DateTime cashActionTime);
    }
}
