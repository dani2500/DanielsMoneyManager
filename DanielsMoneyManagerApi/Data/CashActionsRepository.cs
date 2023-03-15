using DanielsMoneyManagerApi.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace DanielsMoneyManagerApi.Data
{
    public class CashActionsRepository : ICashActionsRepository
    {
        private readonly DapperContext _context;
        public CashActionsRepository(DapperContext context)
        {
            _context = context;
        }

        public List<CashAction> GetCashActions(int userId, DateTime fromTime, DateTime toTime)
        {
            List<CashAction> actions = new List<CashAction>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("From_Time", fromTime);
                parameters.Add("To_Time", toTime);


                actions = connection.Query<CashAction>("Cash_Actions_Get", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return actions;
        }
    }
}
