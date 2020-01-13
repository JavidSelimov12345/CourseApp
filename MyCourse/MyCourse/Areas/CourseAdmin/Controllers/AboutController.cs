using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCourse.Data;
using MyCourse.Models;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Hosting;
using static MyCourse.Extentions.IFormFileExtentions;
using static MyCourse.Utilities.Utilities;

namespace MyCourse.Areas.CourseAdmin.Controllers { 
    [Area("CourseAdmin")]
    public class AboutController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public AboutController(ApplicationDbContext context,IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Abouts.ToList());
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            About about = await _context.Abouts.FindAsync(id);

            if (about == null) return NotFound();

            return View(about);


        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(About about)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (about.Photo == null)
            {
                ModelState.AddModelError("Photo", "image secilmelidir");
                return View();
            }

            if (!about.Photo.isImage())
            {
                ModelState.AddModelError("Photo", "image tipinden olmalidr");
                return View();


            }

            if (!about.Photo.lessThan(2))
            {
                ModelState.AddModelError("Photo", "sekilin olcusu 2 mb ve ya ondan az olmalidir");
                return View();
            }

            //save
            string fileName = await about.Photo.Save(_env.WebRootPath, "About");

            about.Images = fileName;
            await _context.Abouts.AddAsync(about);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            About about = await _context.Abouts.FindAsync(id);

            if (about == null) return NotFound();

            return View(about);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, About about)
        {


            if (!ModelState.IsValid) return View(about);

            About aboutfromDB = await _context.Abouts.FindAsync(about.Id);

            if (about.Photo != null)
            {
                if (!about.Photo.isImage())
                {
                    ModelState.AddModelError("Photo", "file type is not valid");
                    return View(about);
                }
                if (!about.Photo.lessThan(2))
                {
                    ModelState.AddModelError("Photo", "file must be maximum 2 meqabites");
                    return View(about);
                }

                //remove old image and save new image
                RemoveImage(_env.WebRootPath, aboutfromDB.Images);
                aboutfromDB.Images = await about.Photo.Save(_env.WebRootPath, "tutors");





            }



            aboutfromDB.Header = about.Header;
            aboutfromDB.TitleOne = about.TitleOne;
            aboutfromDB.TitleTwo = about.TitleTwo;
            aboutfromDB.TitleThree = about.TitleThree;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }





        [HttpGet]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            About about = await _context.Abouts.FindAsync(id);

            if (about == null) return NotFound();

            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return Content("Id yoxdur");
            About about = await _context.Abouts.FindAsync(id);

            RemoveImage(_env.WebRootPath, about.Images);


            _context.Abouts.Remove(about);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}