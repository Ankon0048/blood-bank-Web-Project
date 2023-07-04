using Microsoft.AspNetCore.Mvc;

namespace blood_bank.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult FAQ()
        {
            return View();
        }
    }
}