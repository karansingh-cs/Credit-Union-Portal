namespace CreditUnionPortal.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty; // "Deposit" or "Withdrawal" type
        public string Description { get; set; } = string.Empty; // Notes
        public DateTime Transactionate { get; set; } = DateTime.Now;
        public Account? Account { get; set; }
    }
}
