using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace blood_bank.Controllers
{
    public class DonateBloodController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DonateBloodController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult DonateBlood()
        {
            ViewBag.Stats = "Donation of Blood";
            return View();
        }

        [HttpPost]
        public IActionResult DonateBlood(AdminHomeData obj)
        {
            TempData["success"] = "Donation Request Sent Successfully";
            obj.Status = "Donation";
            _db.AdminHomeDatas.Add(obj);
            _db.SaveChanges();
            return View();
        }

        public IActionResult RequestBlood()
        {
            ViewBag.Stats = "Request of Blood";
            return View();
        }

        [HttpPost]
        public IActionResult RequestBlood(AdminHomeData obj)
        {
            TempData["success"] = "Blood Request Sent Successfully";
            obj.Status = "Request";
            _db.AdminHomeDatas.Add(obj);
            _db.SaveChanges();
            return View();
        }

        public IActionResult DonateTime()
        {
            ViewBag.Stats = "Donation of Time";
            return View();
        }

        [HttpPost]
        public IActionResult DonateTime(AdminHomeData obj, string? eventname)
        {
            TempData["success"] = "Volunteer Request Sent Successfully";
            obj.Status = "Volunteer";
            EventDesc? ed = _db.EventDescs.Find(eventname);
            if (ed != null)
            {
                obj.Date = ed.Date;
            }
            _db.AdminHomeDatas.Add(obj);
            _db.SaveChanges();
            return View();
        }

        public IActionResult DonateMoney()
        {
            ViewBag.Stats = "Donation of Funds";
            return View();
        }

        [HttpPost]
        public IActionResult DonateMoney(Transaction obj)
        {
            TempData["success"] = "Donation Request Sent Successfully";
            _db.Transactions.Add(obj);
            _db.SaveChanges();
            return View();
        }
    }
}