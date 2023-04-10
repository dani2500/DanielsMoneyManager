namespace DanielsMoneyManagerApi.Dtos
{
    public class FundsStatusResponseDto
    {
        public int fundId { get; set; }
        public DateTime firstInvestmentDate { get; set; }
        public DateTime lastInvestmentDate { get; set; }
        public float investedSum { get; set; }
        public float actualSum { get; set; }
        public float profit { get; set; }
    }
}
