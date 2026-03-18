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
                Balance = 2000.0m,  // m tells the amount is decimal not double, Use decimal not double — financial data requires exact precision
                OpenedDate = DateTime.Now
            },
            new Account
            {
                MemberId = john.MemberId,
                AccountType = "Checking",
                Balance = 100.0m,
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
                AccountType = "Checking",
                Balance = -40.54m,
                OpenedDate = DateTime.Now
            },
            new Account
            {
                MemberId = singh.MemberId,
                AccountType = "Savings",
                Balance = -12.53m,
                OpenedDate = DateTime.Now
            });

            context.SaveChanges();

            var johnSavings = context.Accounts.First(a => a.MemberId == john.MemberId && a.AccountType == "Savings");
            var johnChecking = context.Accounts.First(a => a.MemberId == john.MemberId && a.AccountType == "Checking");
            var kingSavings = context.Accounts.First(a => a.MemberId == king.MemberId && a.AccountType == "Savings");
            var kingChecking = context.Accounts.First(a => a.MemberId == king.MemberId && a.AccountType == "Checking");
            var singhSavings = context.Accounts.First(a => a.MemberId == singh.MemberId && a.AccountType == "Savings");
            var singhChecking = context.Accounts.First(a => a.MemberId == singh.MemberId && a.AccountType == "Checking");

            context.Transactions.AddRange(
                new Transaction
                {
                    AccountId = johnSavings.AccountId,
                    Amount = 120.00m,
                    TransactionDate = new DateTime(2026, 03, 03),
                    Description = "ATM Withdrawal",
                    Type = "Withdrawal"
                },
                new Transaction
                { 
                    AccountId = johnChecking.AccountId,
                    Amount = 244.98m,
                    Type = "Deposit",
                    Description = "Check",
                    TransactionDate = new DateTime(2025, 9, 7)
                },
                new Transaction
                {
                    AccountId = johnChecking.AccountId,
                    Amount = 10.00m,
                    TransactionDate = new DateTime(2026, 03, 03),
                    Description = "ATM Withdrawal",
                    Type = "Withdrawal"
                },
                new Transaction
                {
                    AccountId = johnSavings.AccountId,
                    Amount = 24.98m,
                    Type = "Deposit",
                    Description = "Check",
                    TransactionDate = new DateTime(2025, 9, 7)
                },
                 new Transaction
                 {
                     AccountId = kingChecking.AccountId,
                     Amount = 120.98m,
                     TransactionDate = new DateTime(2026, 03, 03),
                     Description = "Direct Deposit",
                     Type = "Deposit"
                 },
                new Transaction
                {
                    AccountId = kingSavings.AccountId,
                    Amount = 2344.98m,
                    Type = "Deposit",
                    Description = "Check",
                    TransactionDate = new DateTime(2005, 9, 7)
                },
                new Transaction
                {
                    AccountId = singhChecking.AccountId,
                    Amount = 50.00m,
                    TransactionDate = new DateTime(2016, 03, 03),
                    Description = " Direct Deposit",
                    Type = "Deposit"
                },
                 new Transaction
                 {
                     AccountId = singhChecking.AccountId,
                     Amount = 90.54m,
                     TransactionDate = new DateTime(2016, 03, 03),
                     Description = "ATM",
                     Type = "Withdrawal"
                 },
                 new Transaction
                 {
                     AccountId = singhSavings.AccountId,
                     Amount = 50.00m,
                     TransactionDate = new DateTime(2016, 03, 03),
                     Description = " Direct Deposit",
                     Type = "Deposit"
                 },
                new Transaction
                {
                    AccountId = singhSavings.AccountId,
                    Amount = 62.53m,
                    Type = "Withdrawal",
                    Description = "ATM",
                    TransactionDate = new DateTime(2021, 9, 7)
                }
            );

            context.SaveChanges();
        }

    }
}
