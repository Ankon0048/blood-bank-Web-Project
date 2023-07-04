using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace blood_bank.Controllers
{
    public class ManageUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _con;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ManageUserController(ApplicationDbContext db, IHttpContextAccessor con, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _con = con;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Notifications()
        {
            List<UserNotification> list = _db.UserNotifications.ToList();
            list.Reverse();
            return View(list);
        }

        [HttpPost]
        public IActionResult Notifications(int? count)
        {
            UserNotification? obj = _db.UserNotifications.Find(count);
            if (obj != null)
            {
                TempData["success"] = "Message marked as read";
                obj.Mark = "read";
                _db.UserNotifications.Update(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("Notifications", "ManageUser");
        }

        public IActionResult UpdateProfile()
        {
            Userprofile? data = _db.Userprofiles.Find(@_con.HttpContext.Session.GetString("userid"));
            return View(data);
        }

        public IActionResult Reform()
        {
            Userprofile? data = _db.Userprofiles.Find(@_con.HttpContext.Session.GetString("userid"));
            return View(data);
        }

        [HttpPost]
        public IActionResult Reform(Userprofile obj, IFormFile? pfile)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (pfile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(pfile.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images/product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        pfile.CopyTo(fileStream);
                    }
                    obj.Imageurl = @"/images/product/" + fileName;
                }
            }
            TempData["success"] = "Profile Updated";
            string Key = "abcd1231@#$%^";
            string pass = obj.Password + Key;
            var passbytes = Encoding.UTF8.GetBytes(pass);
            obj.Password = Convert.ToBase64String(passbytes);
            TempData["success"] = "Account Created Successfully";
            _db.Userprofiles.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("UpdateProfile", "ManageUser");
        }

        public IActionResult History()
        {
            string? userid = _con.HttpContext.Session.GetString("userid");
            List<ReportData> list = _db.ReportDatas.Where(u => u.UserId == userid).ToList();
            return View(list);
        }

        public IActionResult Show(int id)
        {
            UserNotification? obj = _db.UserNotifications.Find(id);
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UserNotification? record = _db.UserNotifications.Find(id);

            if (record != null)
            {
                _db.UserNotifications.Remove(record);
                _db.SaveChanges();
            }
            return RedirectToAction("Notifications", "ManageUser");
        }

        [HttpPost]
        public ActionResult Mark(int id)
        {
            UserNotification? data = _db.UserNotifications.Find(id);
            if (data != null)
            {
                data.Mark = "read";
                _db.UserNotifications.Update(data);
            }
            _db.SaveChanges();
            return RedirectToAction("Notifications", "ManageUser");
        }
    }
}