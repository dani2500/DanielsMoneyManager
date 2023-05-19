namespace DanielsMoneyManagerApi.Dtos
{
    public class FundsStatusResponseDto
    {
        public int fundId { get; set; }
        public DateTime? firstInvestmentDate { get; set; }
        public DateTime? lastInvestmentDate { get; set; }
        public decimal investedSum { get; set; }
        public decimal actualSum { get; set; }
        public decimal profit { get; set; }
    }
}
