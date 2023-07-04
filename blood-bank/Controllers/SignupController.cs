using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace blood_bank.Controllers
{
    public class SignupController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _con;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SignupController(ApplicationDbContext db, IHttpContextAccessor con, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _con = con;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Userprofile obj, IFormFile? pfile)
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
            else
            {
                TempData["error"] = "Give Correct Informations";
                return RedirectToAction("SignUp", "SignUp");
            }
            obj.Role = "user";
            string Key = "abcd1231@#$%^";
            string pass = obj.Password + Key;
            var passbytes = Encoding.UTF8.GetBytes(pass);
            obj.Password = Convert.ToBase64String(passbytes);
            TempData["success"] = "Successfully Occured";
            _db.Userprofiles.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("index", "Home");
        }
    }
}