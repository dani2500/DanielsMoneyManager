using DanielsMoneyManagerApi.Models;
using Dapper;
using System.Data;

namespace DanielsMoneyManagerApi.Data
{
    public class FundsRepository : IFundsRepository
    {
        private readonly DapperContext _context;
        public FundsRepository(DapperContext context)
        {
            _context = context;
        }

        public List<Fund> GetFunds(int userId)
        {
            List<Fund> funds = new List<Fund>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);

                funds = connection.Query<Fund>("Funds_Get", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return funds;
        }

        public List<FundStatus> GetFundsStatus(int userId, DateTime toTime)
        {
            List<FundStatus> statuses = new List<FundStatus>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("To_Time", toTime);

                statuses = connection.Query<FundStatus>("Funds_Get_Status", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return statuses;
        }

        public FundsStatusTotal GetFundsStatusTotal(int userId, DateTime toTime)
        {
            FundsStatusTotal status = new FundsStatusTotal();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("To_Time", toTime);

                status = connection.QueryFirstOrDefault<FundsStatusTotal>("Funds_Get_Status_Total", parameters, commandType: CommandType.StoredProcedure);
            }

            return status;
        }

        public List<FundStatusHistoryUnit> GetFundsStatusHistory(int userId, int maxTimeBackMonths)
        {
            List<FundStatusHistoryUnit> balances = new List<FundStatusHistoryUnit>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("Max_Time_Back_Months", maxTimeBackMonths);


                balances = connection.Query<FundStatusHistoryUnit>("Funds_Get_Status_History", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return balances;
        }

        public Fund GetFundById(int fundId)
        {
            Fund fund = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Fund_ID", fundId);

                fund = connection.QueryFirstOrDefault<Fund>("Funds_Get_By_ID", parameters, commandType: CommandType.StoredProcedure);
            }

            return fund;
        }

        public Fund GetFundByName(int userId, string fundName)
        {
            Fund fund = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("Fund_Name", fundName.Trim());

                fund = connection.QueryFirstOrDefault<Fund>("Funds_Get_By_Name", parameters, commandType: CommandType.StoredProcedure);
            }

            return fund;
        }



        public Fund InsertFund(int userId, string fundName)
        {
            Fund fund = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("User_ID", userId);
                parameters.Add("Fund_Name", fundName.Trim());

                fund = connection.QueryFirstOrDefault<Fund>("Funds_Insert", parameters, commandType: CommandType.StoredProcedure);
            }

            return fund;
        }

        public void UpdateFund(int fundId, string fundName)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Fund_Name", fundName.Trim());
                parameters.Add("Fund_ID", fundId);

                connection.QueryFirstOrDefault<Category>("Funds_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteFund(int fundId)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Fund_ID", fundId);

                connection.Query("Funds_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
