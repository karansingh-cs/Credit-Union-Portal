using System.ComponentModel.DataAnnotations;

namespace CreditUnionPortal.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please select a type")]
        public string Type { get; set; } = string.Empty; // "Deposit" or "Withdrawal"

        [Required(ErrorMessage = "Please enter a description")]
        [StringLength(100, ErrorMessage = "Max 100 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime TransactionDate { get; set; } = DateTime.Now;

        public Account? Account { get; set; }
    }
}
