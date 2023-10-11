using Health_Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Health_Insurance.Controllers
{
    public class LoginAndRegisterController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ModelContext _context;

        public LoginAndRegisterController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Userid,Roleid,Fullname,Image,Birthday,Phonenumber,Gender,City,Status,Email,Password")] Userccount userccount)
        {
            if (ModelState.IsValid)
            {
                if (userccount.ImageFile != null)
                {
                    string wwwRootPath = webHostEnvironment.WebRootPath;

                    string fileName = Guid.NewGuid().ToString() + userccount.ImageFile.FileName;

                    string path = Path.Combine(wwwRootPath + "/Images/" + fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await userccount.ImageFile.CopyToAsync(fileStream);
                    }

                    userccount.Image = fileName;
                }

                var user=_context.Userccounts.Where(x =>x.Email == userccount.Email).FirstOrDefault();

                if (user == null)
                {
                    userccount.Roleid = 2;

                    _context.Add(userccount);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Homes");


                }
                else{
                    ViewBag.Error = "Email is alredy used, please try another one.";
                }

                //Userccount userccount1 = new Userccount();
                // userccount1.Password = userccount.Password;
                // userccount1.Email = userccount.Email;
            }
            ViewData["Roleid"] = new SelectList(_context.Roles, "Roleid", "Roleid", userccount.Roleid);
            return View(userccount);
        }



        [HttpPost]

        public async Task<IActionResult> Login([Bind("Userid,Roleid,Fullname,Image,Birthday,Phonenumber,Gender,City,Status,Email,Password")] Userccount userccount)
        {
            var auth = _context.Userccounts.Where(x => x.Email == userccount.Email && x.Password == userccount.Password).FirstOrDefault();

            if (auth != null)
            {

                var user = _context.Userccounts.Where(x => x.Userid == auth.Userid).FirstOrDefault();
                switch (auth.Roleid)
                {
                    case 1:
                        //HttpContext.Session.SetString("Fullname", user.Fullname);
                        //HttpContext.Session.SetString("Email", auth.Email);
                        //HttpContext.Session.SetInt32("Userid", (int)auth.Userid);

                        return RedirectToAction("Index", "Admin");
                    case 2:
                        //HttpContext.Session.SetString("Fullname", user.Fullname);
                        //HttpContext.Session.SetString("Email", auth.Email);
                        //HttpContext.Session.SetString("Image", user.Image);
                        //HttpContext.Session.SetInt32("Userid", (int)auth.Userid);
                        return RedirectToAction("Index", "Homes");
                }

            }
            else
            {
                ViewBag.Error = "Wrong credentional";

            }

            return View();

        }



    }
}
