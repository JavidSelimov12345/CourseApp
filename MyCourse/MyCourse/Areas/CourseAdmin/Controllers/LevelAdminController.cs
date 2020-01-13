using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCourse.Models;
using MyCourse.Data;
using Microsoft.Extensions.Hosting;

namespace MyCourse.Areas.CourseAdmin.Controllers
{

    [Area("CourseAdmin")]
    public class LevelAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostEnvironment _env;

        public LevelAdminController(ApplicationDbContext context,IHostEnvironment env)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Levels.ToList().OrderByDescending(p=>p.Id));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            Level level = await _context.Levels.FindAsync(id);

            if (level == null) return NotFound();

            return View(level);


        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Level level)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task <IActionResult> Delete(int? id)
        {

            if (id == null) return NotFound();
            Level level = await _context.Levels.FindAsync(id);

            if (level == null) return NotFound();

            return View(level);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeletePost(int? id)
        {

            if (id == null) return Content("Id yoxdur");
            Level level = await _context.Levels.FindAsync(id);

            //RemoveImage(_env.WebRootPath, tutor.image);


            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            Level level  = await _context.Levels.FindAsync(id);

            if (level == null) return NotFound();

            return View(level);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Level level)
        {


            if (!ModelState.IsValid) return View(level);

            Level LevelfromDB = await _context.Levels.FindAsync(level.Id);

            //if (tutor.Photo != null)
            //{
            //    if (!tutor.Photo.isImage())
            //    {
            //        ModelState.AddModelError("Photo", "file type is not valid");
            //        return View(tutor);
            //    }
            //    if (!tutor.Photo.lessThan(2))
            //    {
            //        ModelState.AddModelError("Photo", "file must be maximum 2 meqabites");
            //        return View(tutor);
            //    }

            //    //remove old image and save new image
            //    RemoveImage(_env.WebRootPath, tutorfromDB.image);
            //    tutorfromDB.image = await tutor.Photo.Save(_env.WebRootPath, "tutors");





            //}



            LevelfromDB.Header = level.Header;
            LevelfromDB.Content = level.Content;
            


            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}