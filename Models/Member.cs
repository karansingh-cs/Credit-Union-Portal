using System.ComponentModel.DataAnnotations;

namespace CreditUnionPortal.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Active";
        [Display(Name = "Member Since")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
