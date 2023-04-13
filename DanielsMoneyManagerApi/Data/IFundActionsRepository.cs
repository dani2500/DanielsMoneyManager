﻿using DanielsMoneyManagerApi.Models;

namespace DanielsMoneyManagerApi.Data
{
    public interface IFundActionsRepository
    {
        void DeleteFundActions(string fundActionIds, int userId);
        List<FundAction> GetFundActions(DateTime fromTime, DateTime toTime, int fundId, int userId);
        FundAction InsertFundActions(int fundId, float investmentSum, float currentState, string note, DateTime investmentDate);
        void UpdateFundActions(int fundActionId, int fundId, float investmentSum, float currentState, string note, DateTime investmentDate);
    }
}