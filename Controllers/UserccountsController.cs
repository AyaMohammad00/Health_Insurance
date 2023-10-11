using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Health_Insurance.Models;

namespace Health_Insurance.Controllers
{
    public class UserccountsController : Controller
    {
        private readonly ModelContext _context;

        public UserccountsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Userccounts
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Userccounts.Include(u => u.Role);
            return View(await modelContext.ToListAsync());
        }

        // GET: Userccounts/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Userccounts == null)
            {
                return NotFound();
            }

            var userccount = await _context.Userccounts
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (userccount == null)
            {
                return NotFound();
            }

            return View(userccount);
        }

        // GET: Userccounts/Create
        public IActionResult Create()
        {
            ViewData["Roleid"] = new SelectList(_context.Roles, "Roleid", "Roleid");
            return View();
        }

        // POST: Userccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userid,Roleid,Fullname,Image,Birthday,Phonenumber,Gender,City,Status,Email,Password,ImageFile")] Userccount userccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Roleid"] = new SelectList(_context.Roles, "Roleid", "Roleid", userccount.Roleid);
            return View(userccount);
        }

        // GET: Userccounts/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Userccounts == null)
            {
                return NotFound();
            }

            var userccount = await _context.Userccounts.FindAsync(id);
            if (userccount == null)
            {
                return NotFound();
            }
            ViewData["Roleid"] = new SelectList(_context.Roles, "Roleid", "Roleid", userccount.Roleid);
            return View(userccount);
        }

        // POST: Userccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Userid,Roleid,Fullname,Image,Birthday,Phonenumber,Gender,City,Status,Email,Password,ImageFile")] Userccount userccount)
        {
            if (id != userccount.Userid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserccountExists(userccount.Userid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Roleid"] = new SelectList(_context.Roles, "Roleid", "Roleid", userccount.Roleid);
            return View(userccount);
        }

        // GET: Userccounts/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Userccounts == null)
            {
                return NotFound();
            }

            var userccount = await _context.Userccounts
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (userccount == null)
            {
                return NotFound();
            }

            return View(userccount);
        }

        // POST: Userccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Userccounts == null)
            {
                return Problem("Entity set 'ModelContext.Userccounts'  is null.");
            }
            var userccount = await _context.Userccounts.FindAsync(id);
            if (userccount != null)
            {
                _context.Userccounts.Remove(userccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserccountExists(decimal id)
        {
          return (_context.Userccounts?.Any(e => e.Userid == id)).GetValueOrDefault();
        }
    }
}
