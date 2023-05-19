namespace DanielsMoneyManagerApi.Dtos
{
    public class FundActionInsertDto
    {
        public int fundId { get; set; }
        public decimal investmentSum { get; set; }
        public decimal currentState { get; set; }
        public string? note { get; set; }
        public DateTime investmentDate { get; set; }
    }
}
