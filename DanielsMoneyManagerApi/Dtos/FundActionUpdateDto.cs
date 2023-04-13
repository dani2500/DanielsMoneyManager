namespace DanielsMoneyManagerApi.Dtos
{
    public class FundActionUpdateDto
    {
        public int fundActionId { get; set; }
        public int fundId { get; set; }
        public float investmentSum { get; set; }
        public float currentState { get; set; }
        public string? note { get; set; }
        public DateTime investmentDate { get; set; }
    }
}
