namespace DanielsMoneyManagerApi.Models
{
    public class FundStatus
    {
        public int Fund_ID { get; set; }
        public DateTime First_Investment_Date { get; set; }
        public DateTime Last_Investment_Date { get; set; }
        public float Invested_Sum { get; set; }
        public float Actual_Sum { get; set; }
        public float Profit { get; set; }
    }
}
