using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaProjesi.Models;

namespace WebProgramlamaProjesi.Controllers
{
    [Authorize]

    public class UserEntitiesController : Controller
    {
        private readonly AppDbContext _context;

        public UserEntitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: UserEntities
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserEntity.ToListAsync());
        }

        // GET: UserEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserEntity == null)
            {
                return NotFound();
            }

            var userEntity = await _context.UserEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return View(userEntity);
        }

        // GET: UserEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password")] UserEntity userEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userEntity);
        }

        // GET: UserEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserEntity == null)
            {
                return NotFound();
            }

            var userEntity = await _context.UserEntity.FindAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            return View(userEntity);
        }

        // POST: UserEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Password")] UserEntity userEntity)
        {
            if (id != userEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEntityExists(userEntity.Id))
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
            return View(userEntity);
        }

        // GET: UserEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserEntity == null)
            {
                return NotFound();
            }

            var userEntity = await _context.UserEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userEntity == null)
            {
                return NotFound();
            }

            return View(userEntity);
        }

        // POST: UserEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserEntity == null)
            {
                return Problem("Entity set 'AppDbContext.UserEntity'  is null.");
            }
            var userEntity = await _context.UserEntity.FindAsync(id);
            if (userEntity != null)
            {
                _context.UserEntity.Remove(userEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEntityExists(int id)
        {
          return _context.UserEntity.Any(e => e.Id == id);
        }
    }
}
