﻿using DanielsMoneyManagerApi.Models;
using Dapper;
using System;
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

        public List<CashAction> GetCashActions(DateTime fromTime, DateTime toTime, int categoryId, int userId)
        {
            List<CashAction> actions = new List<CashAction>();

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("From_Time", fromTime);
                parameters.Add("To_Time", toTime);
                parameters.Add("Category_ID", categoryId);
                parameters.Add("User_ID", userId);

                actions = connection.Query<CashAction>("Cash_Actions_Get", parameters, commandType: CommandType.StoredProcedure).ToList();
            }

            return actions;
        }

        public CashAction InsertCashActions(int categoryId, string description, decimal sum, DateTime cashActionTime)
        {
            CashAction action = null;

            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Category_ID", categoryId);
                parameters.Add("Description", description);
                parameters.Add("Sum", sum);
                parameters.Add("Cash_Action_Time", cashActionTime);

                action = connection.QuerySingleOrDefault<CashAction>("Cash_Actions_Insert", parameters, commandType: CommandType.StoredProcedure);
            }

            return action;
        }

        public void DeleteCashActions(string cashActionIds, int userId)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Cash_Action_IDs", cashActionIds);
                parameters.Add("User_ID", userId);

                connection.QuerySingleOrDefault("Cash_Actions_Delete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateCashActions(int cashActionId, int categoryId, string description, decimal sum, DateTime cashActionTime)
        {
            using (var connection = _context.CreateConnection())
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Cash_Action_ID", cashActionId);
                parameters.Add("Category_ID", categoryId);
                parameters.Add("Description", description);
                parameters.Add("Sum", sum);
                parameters.Add("Cash_Action_Time", cashActionTime);

                connection.QuerySingleOrDefault("Cash_Actions_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
