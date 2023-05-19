using DanielsMoneyManagerApi.Models;

namespace DanielsMoneyManagerApi.Data
{
    public interface ICashActionsRepository
    {
        List<CashAction> GetCashActions(DateTime fromTime, DateTime toTime, int categoryId, int userId);
        CashAction InsertCashActions(int categoryId, string description, decimal sum, DateTime cashActionTime);
        void DeleteCashActions(string cashActionIds, int userId);
        void UpdateCashActions(int cashActionId, int categoryId, string description, decimal sum, DateTime cashActionTime);
    }
}
