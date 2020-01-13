using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MyCourse.Data;
using MyCourse.Models;

namespace MyCourse.Areas.CourseAdmin.Controllers
{
    [Area("CourseAdmin")]
    public class BenefitController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostEnvironment _env;

        public BenefitController(ApplicationDbContext context, IHostEnvironment env)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Benefits.ToList().OrderByDescending(p => p.id));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            Benefit benefit = await _context.Benefits.FindAsync(id);

            if (benefit == null) return NotFound();

            return View(benefit);


        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Benefit benefit)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.Benefits.AddAsync(benefit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null) return NotFound();
            Benefit  benefit = await _context.Benefits.FindAsync(id);

            if (benefit == null) return NotFound();

            return View(benefit);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {

            if (id == null) return Content("Id yoxdur");
            Benefit benefit = await _context.Benefits.FindAsync(id);

            //RemoveImage(_env.WebRootPath, tutor.image);


            _context.Benefits.Remove(benefit);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            Benefit benefit = await _context.Benefits.FindAsync(id);

            if (benefit == null) return NotFound();

            return View(benefit);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Benefit benefit)
        {


            if (!ModelState.IsValid) return View(benefit);

            Benefit benefitfromDB = await _context.Benefits.FindAsync(benefit.id);

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



            benefitfromDB.number = benefit.number;
            benefitfromDB.Content = benefit.Content;
           

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


    }
}