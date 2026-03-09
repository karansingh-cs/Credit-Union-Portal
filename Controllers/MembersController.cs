using CreditUnionPortal.Data;
using CreditUnionPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CreditUnionPortal.Controllers
{
    public class MembersController : Controller
    {
        private readonly AppDbContext _context;
        public MembersController(AppDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index() {
            var members = _context.Members.ToList();
            return View(members);
        }
    }
}
