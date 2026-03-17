using CreditUnionPortal.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditUnionPortal.Controllers
{
    public class AccountsController : Controller
    {
        private readonly AppDbContext _context;

        public AccountsController(AppDbContext context)
        { 
            _context = context;
        }

        public IActionResult Details(int id)
        {
            var account = _context.Accounts // Go to the Accounts table
                .Include(a => a.Transactions) // Also bring along each account's transactions
                .FirstOrDefault(a => a.AccountId == id); // From all those accounts, find the first one where the AccountId matches the id I was given
            if (account == null)
                return NotFound();
            
            return View(account);
        }

    }
}
