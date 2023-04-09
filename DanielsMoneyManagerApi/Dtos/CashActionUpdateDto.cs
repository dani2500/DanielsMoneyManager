﻿namespace DanielsMoneyManagerApi.Dtos
{
    public class CashActionUpdateDto
    {
        public int cashActionId { get; set; }
        public int categoryId { get; set; }
        public float sum { get; set; }
        public string description { get; set; }
        public DateTime cashActionTime { get; set; }
    }
}
