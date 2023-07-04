using Microsoft.AspNetCore.Mvc;

namespace blood_bank.Controllers
{
    public class BloodBasicsController : Controller
    {
        public IActionResult BloodBasics()
        {
            return View();
        }
    }
}