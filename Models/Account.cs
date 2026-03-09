using System.ComponentModel.DataAnnotations;

namespace CreditUnionPortal.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        [Required]
        public int MemberId { get; set; }
        [Required]
        [Display(Name = "Account Type")]
        public string AccountType { get; set; } = string.Empty; //checking or Savings
        [Required]
        [DataType(DataType.Currency)]
        public decimal Balance { get; set; }
        [Display(Name = "Opened Date")]
        public DateTime OpenedDate { get; set; } = DateTime.Now;
        public Member? Member { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
