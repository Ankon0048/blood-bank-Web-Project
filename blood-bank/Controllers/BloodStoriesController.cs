using blood_bank.data;
using blood_bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace blood_bank.Controllers
{
    public class BloodStoriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BloodStoriesController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult BloodStories()
        {
            List<BloodStory> list = _db.BloodStories.ToList();

            return View(list);
        }

        public IActionResult AddStory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStory(BloodStory obj, IFormFile? pfile)
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
            TempData["success"] = "Story Added Successfully";
            _db.BloodStories.Add(obj);
            _db.SaveChanges();
            return View();
        }
    }
}