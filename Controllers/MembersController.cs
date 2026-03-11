using CreditUnionPortal.Data;
using CreditUnionPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditUnionPortal.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;
        public MembersController(AppDbContext context) // context = database connection
        {
            _context = context;
        }
        public IActionResult Index() {
            var members = _context.Members.ToList(); //context.Members = the Members TABLE
            return View(members);
        }
        public IActionResult Details(int id)
        {
            var member = _context.Members // context.Accounts = the Accounts TABLE
                .Include(m => m.Accounts)
                .FirstOrDefault(m => m.MemberId == id);

            if (member == null)
                return NotFound();
            return View(member);
        }
    }
}
