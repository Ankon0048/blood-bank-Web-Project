using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace blood_bank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _con;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor con, ApplicationDbContext db)
        {
            _logger = logger;
            _con = con;
            _db = db;
        }

        public IActionResult Index()
        {
            List<ReportData> list = _db.ReportDatas.ToList();
            List<EventDesc> data = _db.EventDescs.Where(u => u.Status == "Upcoming").ToList();
            List<string> upliname = new List<string>();
            List<string> uplidate = new List<string>();
            List<string> upliloc = new List<string>();
            List<string> uplitime = new List<string>();
            foreach (var obj in data)
            {
                upliname.Add(obj.EventName);
                uplidate.Add(obj.Date);
                upliloc.Add(obj.Location);
                uplitime.Add(obj.Time);
            }
            ViewBag.upliname = upliname;
            ViewBag.uplidate = uplidate;
            ViewBag.upliloc = upliloc;
            ViewBag.uplitime = uplitime;
            return View(list);
        }

        public IActionResult LogOut()
        {
            _con.HttpContext.Session.Clear();
            _con.HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}