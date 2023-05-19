namespace DanielsMoneyManagerApi.Models
{
    public class CategoryBalanceResponseDto
    {
        public int categoryId { get; set; }
        public decimal categoryBalance { get; set; }
        public int cashActionsCount { get; set; }   
    }
}
