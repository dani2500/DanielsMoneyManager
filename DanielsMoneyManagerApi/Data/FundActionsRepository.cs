using DanielsMoneyManagerApi.Models;
using Dapper;
using System.Data;

namespace DanielsMoneyManagerApi.Data
{
    public class FundActionsRepository : IFundActionsRepository
    {
        private readonly DapperContext _context;
        public FundActionsRepository(DapperContext context)
        {
            _context = context;
        }

        public List<FundAction> GetFundActions(DateTime fromTime, DateTime toTime, int fundId, int userId)
        {
            List<FundAction> actions = new List<FundAction>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("From_Time", fromTime);
                parameters.Add("To_Time", toTime);
                parameters.Add("Fund_ID", fundId);
                parameters.Add("User_ID", userId);

                actions = connection.Query<FundAction>("Fund_Actions_Get", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return actions;
        }

        public FundAction InsertFundActions(int fundId, decimal investmentSum, decimal currentState, string note, DateTime investmentDate)
        {
            FundAction action = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Fund_ID", fundId);
                parameters.Add("Investment_Sum", investmentSum);
                parameters.Add("Current_State", currentState);
                parameters.Add("Note", note);
                parameters.Add("Investment_Date", investmentDate);

                action = connection.QuerySingleOrDefault<FundAction>("Fund_Actions_Insert", parameters, commandType: CommandType.StoredProcedure);
            }

            return action;
        }

        public void DeleteFundActions(string fundActionIds, int userId)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Fund_Action_IDs", fundActionIds);
                parameters.Add("User_ID", userId);

                connection.QuerySingleOrDefault("Fund_Actions_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateFundActions(int fundActionId, int fundId, decimal investmentSum, decimal currentState, string note, DateTime investmentDate)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Fund_Action_ID", fundActionId);
                parameters.Add("Fund_ID", fundId);
                parameters.Add("Investment_Sum", investmentSum);
                parameters.Add("Current_State", currentState);
                parameters.Add("Note", note);
                parameters.Add("Investment_Date", investmentDate);

                connection.QuerySingleOrDefault("Fund_Actions_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
