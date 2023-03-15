using DanielsMoneyManagerApi.Models;

namespace DanielsMoneyManagerApi.Data
{
    public interface ICashActionsRepository
    {
        List<CashAction> GetCashActions(int userId, DateTime fromTime, DateTime toTime);
    }
}
