using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace blood_bank.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _con;

        public LoginController(ApplicationDbContext db, IHttpContextAccessor con)
        {
            _db = db;
            _con = con;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userid, string password)
        {
            Userprofile? us = _db.Userprofiles.Find(userid);
            if (us != null)
            {
                string Key = "abcd1231@#$%^";
                string pass = password + Key;
                var passbytes = Encoding.UTF8.GetBytes(pass);
                string p = Convert.ToBase64String(passbytes);
                us = _db.Userprofiles.FirstOrDefault(u => u.Password == p && u.UserID == userid);
                if (us != null)
                {
                    /*if (rem == true)
                    {
                        *//*var options = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(7)
                        };
                        var valus = us.UserID.ToString();
                        var valrol = us.Role.ToString();
                        Response.Cookies.Append("cookuserid", valus, options);
                        Response.Cookies.Append("cookrole", valrol, options);*//*
                        Response.Cookies.Append("Username", us.UserID, new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(30) // Set the expiration date to make it persistent
                        });
                        Response.Cookies.Append("Userrole", us.Role, new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(30) // Set the expiration date to make it persistent
                        });
                    }*/
                    _con.HttpContext.Session.SetString("userid", us.UserID.ToString());
                    _con.HttpContext.Session.SetString("role", us.Role.ToString());
                    _con.HttpContext.Session.SetString("img", us.Imageurl.ToString());
                    List<UserNotification> noti = _db.UserNotifications.Where(u => u.Mark == "unread").ToList();
                    _con.HttpContext.Session.SetString("count", noti.Count.ToString());
                    _con.HttpContext.Session.SetString("img", us.Imageurl.ToString());
                    TempData["success"] = "Logged in Successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["error"] = "Wrong Password";
                    return View();
                }
            }
            else
            {
                TempData["error"] = "No User Found";

                return View();
            }
        }

        public IActionResult ForgotPass()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPass(string? userid, string? newpass, string? pass)
        {
            Userprofile? obj = _db.Userprofiles.Find(userid);
            if (obj != null)
            {
                if (newpass == pass)
                {
                    string Key = "abcd1231@#$%^";
                    string pp = newpass + Key;
                    var passbytes = Encoding.UTF8.GetBytes(pp);
                    string p = Convert.ToBase64String(passbytes);
                    obj.Password = p;
                    _db.Userprofiles.Update(obj);
                    _db.SaveChanges();
                    TempData["success"] = "Password Changed Successfully";
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    TempData["error"] = "Password don't match";
                }
            }
            else
            {
                TempData["error"] = "No User Found";
            }
            return View();
        }
    }
}