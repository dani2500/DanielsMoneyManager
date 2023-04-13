namespace DanielsMoneyManagerApi.Dtos
{
    public class FundActionsGetRequestDto
    {
        public DateTime fromTime { get; set; }
        public DateTime toTime { get; set; }
        public int fundId { get; set; } 
    }
}
