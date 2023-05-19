namespace DanielsMoneyManagerApi.Models
{
    public class FundStatusHistoryUnit
    {
        public int Fund_ID { get; set; }
        public DateTime From_Time { get; set; }
        public DateTime To_Time { get; set; }
        public decimal Status { get; set; }

    }
}
