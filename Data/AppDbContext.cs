using CreditUnionPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CreditUnionPortal.Data
{
    public class AppDbContext : DbContext
    {
        public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; } //creates table called "Members"
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasPrecision(18,2); // 18 is the standard for financial data in SQL Server, gives up to 16 digits before the decimal point

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasPrecision(18,2); // 2 = digits after the decimal point. Money always has two decimal places for cents
        }


    }
}
