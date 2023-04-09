namespace DanielsMoneyManagerApi.Models
{
    public class FundAction
    {
        public int Fund_Action_ID { get; set; }
        public int Fund_ID { get; set; }
        public float Investment_Sum { get; set; }
        public DateOnly Investment_Date {  get; set; }
        public float Current_State { get; set; }
        public string Note { get; set; }

    }
}
