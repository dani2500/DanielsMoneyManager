namespace DanielsMoneyManagerApi.Models
{
    public class FundAction
    {
        public int Fund_Action_ID { get; set; }
        public int Fund_ID { get; set; }
        public decimal Investment_Sum { get; set; }
        public DateTime Investment_Date {  get; set; }
        public decimal Current_State { get; set; }
        public string Note { get; set; }

    }
}
