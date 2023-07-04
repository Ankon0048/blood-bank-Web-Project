using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace blood_bank.Controllers
{
    public class AdminHomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _con;

        public AdminHomeController(ApplicationDbContext db, IHttpContextAccessor con)
        {
            _db = db;
            _con = con;
        }

        public IActionResult AdminHome()
        {
            List<AdminHomeData> list = _db.AdminHomeDatas.ToList();
            ViewBag.Requests = list.Count;
            ViewBag.Hospitals = _db.HospitalDescs.ToList().Count;
            List<int?> values = _db.Transactions.Select(u => u.Amount).ToList();
            ViewBag.Oncamp = _db.EventDescs.Where(u => u.Status == "Ongoing").ToList().Count;
            ViewBag.Penaction = _db.ReportDatas.Where(u => u.Action == "Pending").ToList().Count;
            ViewBag.Story = _db.BloodStories.ToList().Count;
            ViewBag.User = _db.Userprofiles.ToList().Count - 1;
            ViewBag.Trans = _db.Transactions.ToList().Count;
            int? sum = values.Sum();
            if (sum != null)
            {
                ViewBag.Sum = sum;
            }
            else
            {
                ViewBag.Sum = 0;
            }

            return View(list);
        }

        public IActionResult AdminRequests(string id, string status, string username, string number, string bloodgroup, string date, string address, int count, string? email)
        {
            TempData["UserId"] = id;
            TempData["Status"] = status;
            TempData["BloodGroup"] = bloodgroup;
            TempData["Number"] = number;
            TempData["UserName"] = username;
            TempData["Date"] = date;
            TempData["Address"] = address;
            ViewBag.id = id;
            ViewBag.status = status;
            ViewBag.date = date;
            ViewBag.stat = status;
            TempData["mail"] = email;
            ViewBag.mail = email;

            AdminHomeData? obj = _db.AdminHomeDatas.Find(count);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                _db.AdminHomeDatas.Remove(obj);
                _db.SaveChanges();
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            AdminHomeData? obj = _db.AdminHomeDatas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            AdminHomeData? obj = _db.AdminHomeDatas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            TempData["error"] = "Request Denied";
            _db.AdminHomeDatas.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("AdminHome", "AdminHome");
        }

        [HttpPost]
        public IActionResult AdminRequests(string message, int amount, string action, string location)
        {
            TempData.Keep("Status");
            ReportData report = new ReportData
            {
                Amount = amount,
                Action = action,
                Location = location,
                UserId = TempData["UserId"] as string,
                Status = TempData["Status"] as string,
                Bloodgroup = TempData["BloodGroup"] as string,
                Number = TempData["Number"] as string,
                UserName = TempData["UserName"] as string,
                Date = TempData["Date"] as string,
            };
            VolunteerData data = new VolunteerData
            {
                VolunteerID = TempData["UserId"] as string,
                Name = TempData["UserName"] as string,
                Bloodgroup = TempData["BloodGroup"] as string,
                Number = TempData["Number"] as string,
                Address = TempData["Address"] as string,
            };
            UserNotification obj = new UserNotification
            {
                UserId = TempData["UserId"] as string,
                Status = TempData["Status"] as string,
                Date = TempData["Date"] as string,
                Message = message,
                Mark = "unread",
            };

            TempData["success"] = "Request Accepted";
            _db.ReportDatas.Add(report);
            _db.UserNotifications.Add(obj);
            if (TempData["Status"] as string == "Volunteer")
            {
                _db.VolunteerDatas.Add(data);
            }

            _db.SaveChanges();

            //Email Sending Code
            try
            {
                string fromMail = "halgal756@gmail.com";
                string fromPassword = "fyuyafebdeyorwen";

                MailMessage m = new MailMessage();
                m.From = new MailAddress(fromMail);
                if (obj.Status != "Request")
                {
                    m.Subject = obj.Status;
                    m.To.Add(new MailAddress(TempData["mail"] as string));
                    m.Body = "<html><body>" + obj.Message + "</body></html>";
                    m.IsBodyHtml = true;
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential(fromMail, fromPassword),
                        EnableSsl = true
                    };
                    smtpClient.Send(m);
                }
                else
                {
                    List<Userprofile> list = _db.Userprofiles.ToList();
                    foreach (var ob in list)
                    {
                        if (ob.Role == "user" && ob.UserID != obj.UserId)
                        {
                            m.Subject = obj.Status;
                            m.To.Add(new MailAddress(ob.Email));
                            m.Body = "<html><body>" + obj.Message + "</body></html>";
                            m.IsBodyHtml = true;
                            var smtpClient = new SmtpClient("smtp.gmail.com")
                            {
                                Port = 587,
                                Credentials = new NetworkCredential(fromMail, fromPassword),
                                EnableSsl = true
                            };
                            smtpClient.Send(m);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("AdminHome", "AdminHome");
        }

        public IActionResult AdminManagement()
        {
            List<EventDesc> list = _db.EventDescs.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult AdminManagement(string? options, string? selected)
        {
            List<EventDesc> list = _db.EventDescs.ToList();
            if (options == "Location")
            {
                list = _db.EventDescs.Where(u => u.Location.Contains(selected)).ToList();
            }
            else if (options == "Date")
            {
                list = _db.EventDescs.Where(u => u.Date.Contains(selected)).ToList();
            }
            else if (options == "EventName")
            {
                list = _db.EventDescs.Where(u => u.EventName.Contains(selected)).ToList();
            }
            return View(list);
        }

        public IActionResult HospitalManagement()
        {
            List<HospitalDesc> list = _db.HospitalDescs.ToList();
            return View(list);
        }

        [HttpPost]
        public IActionResult HospitalManagement(string? options, string? selected)
        {
            List<HospitalDesc> list = _db.HospitalDescs.ToList();
            if (options == "Location")
            {
                list = _db.HospitalDescs.Where(u => u.Location.Contains(selected)).ToList();
            }
            else if (options == "District")
            {
                list = _db.HospitalDescs.Where(u => u.District.Contains(selected)).ToList();
            }
            else if (options == "HospitalName")
            {
                list = _db.HospitalDescs.Where(u => u.HospitalName.Contains(selected)).ToList();
            }
            return View(list);
        }

        public IActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Userprofile> list = _db.Userprofiles.ToList();
            return Json(new { data = list });
        }
    }
}