namespace DanielsMoneyManagerApi.Models
{
    public class CashAction
    {
        public int Cash_Action_ID { get; set; }
        public int Category_ID { get; set; }
        public float Sum { get; set; }
        public string Description { get; set; }
        public DateTime Cash_Action_Time { get; set; }
        public DateTime Insert_Time { get; set; }
        public DateTime? Update_Time { get; set; }
    }
}
