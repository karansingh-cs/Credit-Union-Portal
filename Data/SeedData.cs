using CreditUnionPortal.Models;
namespace CreditUnionPortal.Data
{
    public static class SeedData
    {
        // Seeds initial data only if database is empty
        public static void Initialize(AppDbContext context) // context = your database connection
        { 

            if (context.Members.Any()) // If there is data already present
                return;
            
            context.Members.AddRange(
                new Member { FirstName = "John", LastName = "Smith", Email = "john@email.com", Status = "Active", CreatedDate = DateTime.Now },
                new Member { FirstName = "King", LastName = "Steve", Email = "king@email.com", Status = "Active", CreatedDate = DateTime.Now },
                new Member { FirstName = "Singh", LastName = "Harman", Email = "singh@email.com", Status = "Flagged", CreatedDate = DateTime.Now }
                );

            context.SaveChanges();

            // Fetch member after SaveChanges so MemberId is populated
            var john = context.Members.First(m => m.FirstName == "John");
            context.Accounts.AddRange(new Account
            {
                MemberId = john.MemberId,
                AccountType = "Savings",
                Balance = 12000.0m,  // m tells the amount is decimal not double, Use decimal not double — financial data requires exact precision
                OpenedDate = DateTime.Now
            },
            new Account
            {
                MemberId = john.MemberId,
                AccountType = "Checking",
                Balance = 1000.0m,
                OpenedDate = DateTime.Now
            });

            var king = context.Members.First(m => m.FirstName == "King");
            context.Accounts.AddRange(new Account
            {
                MemberId = king.MemberId,
                AccountType = "Savings",
                Balance = 12000.0m,
                OpenedDate = DateTime.Now
            },
            new Account
            {
                MemberId = king.MemberId,
                AccountType = "Checking",
                Balance = 1000.0m,
                OpenedDate = DateTime.Now
            });

            var singh = context.Members.First(m => m.FirstName == "Singh");
            context.Accounts.AddRange(new Account
            {
                MemberId = singh.MemberId,
                AccountType = "Savings",
                Balance = -40.54m,
                OpenedDate = DateTime.Now
            },
            new Account
            {
                MemberId = singh.MemberId,
                AccountType = "Checking",
                Balance = -12.53m,
                OpenedDate = DateTime.Now
            });

            context.SaveChanges();


        }

    }
}
