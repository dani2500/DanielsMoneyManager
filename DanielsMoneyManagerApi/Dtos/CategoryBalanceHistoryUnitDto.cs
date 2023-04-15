namespace DanielsMoneyManagerApi.Dtos
{
    public class CategoryBalanceHistoryUnitDto
    {
        public int categoryId { get; set; }
        public DateTime fromTime { get; set; }
        public DateTime toTime { get; set; }
        public decimal balance { get; set; }
    }
}
