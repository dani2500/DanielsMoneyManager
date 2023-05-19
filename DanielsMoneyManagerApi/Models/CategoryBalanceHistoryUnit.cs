namespace DanielsMoneyManagerApi.Models
{
    public class CategoryBalanceHistoryUnit
    {
        public int Category_ID { get; set; }
        public DateTime From_Time { get; set; }
        public DateTime To_Time { get; set; }
        public decimal Balance { get; set; }

    }
}
