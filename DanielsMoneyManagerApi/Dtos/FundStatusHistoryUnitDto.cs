namespace DanielsMoneyManagerApi.Dtos
{
    public class FundStatusHistoryUnitDto
    {
        public int fundId { get; set; }
        public DateTime fromTime { get; set; }
        public DateTime toTime { get; set; }
        public decimal status { get; set; }
    }
}
