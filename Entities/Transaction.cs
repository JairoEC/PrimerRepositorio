﻿namespace WebApplication_NET_CORE.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public DateOnly Date { get; set; }
        public decimal TotalAmount { get; set; }

        public Service Service { get; set; }
        public User User { get; set; }
    }
}
