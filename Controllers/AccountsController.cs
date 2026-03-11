using Microsoft.AspNetCore.Mvc;

namespace CreditUnionPortal.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
