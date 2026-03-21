using CreditUnionPortal.Data;
using CreditUnionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditUnionPortal.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly AppDbContext _context;

        public TransactionsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult AddTransaction(int accountId)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTransaction(int accountId, Transaction transaction)
        {
            // Return the form with errors if validation fails
            if (!ModelState.IsValid)
            {
                var account = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);
                return View(account);
            }

            var acc = _context.Accounts.FirstOrDefault(a => a.AccountId == accountId);

            if (transaction.Type == "Withdrawal")
                acc.Balance -= transaction.Amount;
            else
                acc.Balance += transaction.Amount;

            transaction.AccountId = accountId;
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return RedirectToAction("Details", "Accounts", new { id = accountId });
        }

    }
}
