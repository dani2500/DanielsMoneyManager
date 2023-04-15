namespace DanielsMoneyManagerApi.Models
{
    public class FundStatus
    {
        public int Fund_ID { get; set; }
        public DateTime? First_Investment_Date { get; set; }
        public DateTime? Last_Investment_Date { get; set; }
        public decimal Invested_Sum { get; set; }
        public decimal Actual_Sum { get; set; }
        public decimal Profit { get; set; }
    }
}
