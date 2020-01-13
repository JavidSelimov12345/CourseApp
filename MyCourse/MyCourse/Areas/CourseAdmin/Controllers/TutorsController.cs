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

namespace MyCourse.Areas.CourseAdmin.Controllers
{
    [Area("CourseAdmin")]
    public class TutorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public TutorsController(ApplicationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Tutors.ToList().OrderByDescending(p=>p.Id));
        }


        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();

            Tutor tutor = await _context.Tutors.FindAsync(id);

            if (tutor == null) return NotFound();

            return View(tutor);
           
           
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (tutor.Photo == null)
            {
                ModelState.AddModelError("Photo", "image secilmelidir");
                return View();
            }

            if (!tutor.Photo.isImage())
            {
                ModelState.AddModelError("Photo", "image tipinden olmalidr");
                return View();


            }

            if (!tutor.Photo.lessThan(2))
            {
                ModelState.AddModelError("Photo", "sekilin olcusu 2 mb ve ya ondan az olmalidir");
                return View();
            }

            //save
        string fileName= await  tutor.Photo.Save(_env.WebRootPath,"tutors");

            tutor.image = fileName;
            await _context.Tutors.AddAsync(tutor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task <IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            Tutor tutor = await _context.Tutors.FindAsync(id);

            if (tutor == null) return NotFound();

            return View(tutor);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,Tutor tutor)
        {


            if (!ModelState.IsValid) return View(tutor);

            Tutor tutorfromDB = await _context.Tutors.FindAsync(tutor.Id);

            if (tutor.Photo != null)
            {
                if (!tutor.Photo.isImage())
                {
                    ModelState.AddModelError("Photo", "file type is not valid");
                    return View(tutor);
                }
                if (!tutor.Photo.lessThan(2))
                {
                    ModelState.AddModelError("Photo", "file must be maximum 2 meqabites");
                    return View(tutor);
                }

                //remove old image and save new image
                RemoveImage(_env.WebRootPath, tutorfromDB.image);
                tutorfromDB.image = await tutor.Photo.Save(_env.WebRootPath, "tutors");





            }



            tutorfromDB.Head = tutor.Head;
            tutorfromDB.content = tutor.content;
            tutorfromDB.date = tutor.date;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }





        [HttpGet]
       
        public async Task <IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Tutor tutor = await _context.Tutors.FindAsync(id);

            if (tutor == null) return NotFound();

            return View(tutor);
        }

       [HttpPost]
       [ValidateAntiForgeryToken]
       
       public async Task<IActionResult>  DeletePost(int? id)
        {
            if (id == null) return Content("Id yoxdur");
         Tutor tutor = await _context.Tutors.FindAsync(id);

            RemoveImage(_env.WebRootPath, tutor.image);


            _context.Tutors.Remove(tutor);
           await _context.SaveChangesAsync();

          return  RedirectToAction(nameof(Index));
        }

    }
}