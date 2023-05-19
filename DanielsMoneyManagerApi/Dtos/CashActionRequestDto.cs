namespace DanielsMoneyManagerApi.Dtos
{
    public class CashActionsGetRequestDto
    {
        public DateTime fromTime { get; set; }
        public DateTime toTime { get; set; }
        public int categoryId { get; set; } 
    }
}
