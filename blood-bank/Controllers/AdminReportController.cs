using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace blood_bank.Controllers
{
    public class AdminReportController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _con;

        public AdminReportController(ApplicationDbContext db, IHttpContextAccessor con)
        {
            _db = db;
            _con = con;
        }

        public IActionResult AdminReport()
        {
            return View();
        }

        public IActionResult EditReport(int? id)
        {
            ReportData? obj = _db.ReportDatas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult EditReport(ReportData obj)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Report Updated Successfully";
                _db.ReportDatas.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("AdminReport", "AdminReport");
            }
            TempData["error"] = "Something went wrong!";
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ReportData> list = _db.ReportDatas.ToList();
            return Json(new { data = list });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Transaction> list = _db.Transactions.ToList();
            return Json(new { data = list });
        }

        public IActionResult AdminTrix()
        {
            return View();
        }
    }
}