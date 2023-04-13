namespace DanielsMoneyManagerApi.Dtos
{
    public class FundActionDto
    {
        public int fundActionId { get; set; }
        public int fundId { get; set; }
        public float investmentSum { get; set; }
        public float currentState { get; set; }
        public string note { get; set; }
        public DateTime investmentDate { get; set; }
        public DateTime insertTime { get; set; }
        public DateTime? updateTime { get; set; }
    }
}
