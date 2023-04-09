namespace DanielsMoneyManagerApi.Models
{
    public class BalancesResponseDto
    {
        public int categoryId { get; set; }
        public float categoryBalance { get; set; }
        public int cashActionsCount { get; set; }   
    }
}
