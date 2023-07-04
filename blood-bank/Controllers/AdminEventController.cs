using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace blood_bank.Controllers
{
    public class AdminEventController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AdminEventController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult EventDetail(string? name, string? status)
        {
            List<EventData> list = _db.EventDatas.Where(m => m.EventName == name).ToList();
            ViewData["Status"] = status;
            TempData["eventname"] = name;
            TempData["evna"] = name;
            string j = "asn";
            return View(list);
        }

        public IActionResult AddDonor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDonor(EventData obj)
        {
            obj.EventName = TempData["eventname"] as string;
            TempData["success"] = "Donor Added Successfully";
            _db.EventDatas.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("AdminManagement", "AdminHome");
        }

        public IActionResult HospitalDetail(string? name)
        {
            List<HospitalData> list = _db.HospitalDatas.Where(m => m.HospitalName == name).ToList();
            return View(list);
        }

        public IActionResult AddHospital()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHospital(HospitalDesc obj, IFormFile? pfile)
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
            TempData["success"] = "Hospital Connected Successfully";
            _db.HospitalDescs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("AddHospitalDetail", "AdminEvent");
        }

        public IActionResult AddHospitalDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddHospitalDetail(HospitalData obj)
        {
            TempData["success"] = "Added Record Successfully";
            _db.HospitalDatas.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("HospitalManagement", "AdminHome");
        }

        public IActionResult AllHospitalDetail()
        {
            return View();
        }

        public IActionResult EditAllHospitalDetail(string? name)
        {
            HospitalData? obj = _db.HospitalDatas.Find(name);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult EditAllHospitalDetail(HospitalData obj)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Record updated Successfully";
                _db.HospitalDatas.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("AllHospitalDetail", "AdminEvent");
            }
            TempData["error"] = "Something went wrong";
            return View();
        }

        public IActionResult EventDelete(string? name)
        {
            EventData? data = _db.EventDatas.Where(u => u.EventName == name).FirstOrDefault();
            EventDesc? desc = _db.EventDescs.Find(name);
            if (desc != null)
            {
                _db.EventDescs.Remove(desc);
                _db.SaveChanges();
                return View();
            }
            if (data != null)
            {
                _db.EventDatas.Remove(data);
                _db.SaveChanges();
                return View();
            }
            return RedirectToAction("AdminManagement", "AdminHome");
        }

        public IActionResult HospitalDelete(string? name)
        {
            HospitalData? data = _db.HospitalDatas.Find(name);
            HospitalDesc? desc = _db.HospitalDescs.Find(name);
            if (desc == null || data == null)
            {
                return NotFound();
            }
            TempData["success"] = "Hospital Disconnected Successfully";
            _db.HospitalDatas.Remove(data);
            _db.HospitalDescs.Remove(desc);
            _db.SaveChanges();
            return View();
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<HospitalData> list = _db.HospitalDatas.ToList();
            return Json(new { data = list });
        }

        #endregion API CALLS

        public IActionResult VolunteerDetail(string? status)
        {
            List<VolunteerData> list = _db.VolunteerDatas.ToList();
            ViewData["status"] = status;
            return View(list);
        }

        public IActionResult AddVolunteer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVolunteer(VolunteerData obj)
        {
            TempData["success"] = "Record added successfully";
            _db.VolunteerDatas.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("VolunteerDetail", "AdminEvent");
        }

        public IActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEvent(IFormFile? pfile, EventDesc obj)
        {
            obj.Status = "Upcoming";
            obj.BloodCollected = 0;
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
            TempData["success"] = "Event Created Successfully";
            _db.EventDescs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("AdminManagement", "AdminHome");
        }

        public IActionResult EventUpdate(string? name)
        {
            ViewBag.Name = name;
            EventDesc? obj = _db.EventDescs.Find(name);
            return View(obj);
        }

        [HttpPost]
        public IActionResult EventUpdate(EventDesc obj, IFormFile? fileloc)
        {
            List<int?> values = _db.EventDatas.Select(u => u.Amount).ToList();

            int? sum = values.Sum();
            if (sum != null)
            {
                obj.BloodCollected = sum;
            }
            else
            {
                obj.BloodCollected = 0;
            }
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (fileloc != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileloc.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images/product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        fileloc.CopyTo(fileStream);
                    }
                    obj.Imageurl = @"/images/product/" + fileName;
                }
            }
            TempData["success"] = "Record updated successfully";
            _db.EventDescs.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("AdminManagement", "AdminHome");
        }
    }
}