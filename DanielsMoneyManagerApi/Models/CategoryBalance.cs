﻿namespace DanielsMoneyManagerApi.Models
{
    public class CategoryBalance
    {
        public int Category_ID { get; set; }
        public decimal Category_Balance { get; set; }
        public int Cash_Actions_Count { get; set; }
    }
}
