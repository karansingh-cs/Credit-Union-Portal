using CreditUnionPortal.Data;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTransaction(int accountId, Transactions transaction)
        {
            return View();
        }

    }
}
