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
    public class BackGroundController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _env;

        public BackGroundController(ApplicationDbContext context,IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(_context.Backgrounds.ToList());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            Background background = await _context.Backgrounds.FindAsync(id);

            if (background == null) return NotFound();

            return View(background);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Background background)
        {


            if (!ModelState.IsValid) return View(background);

            Background BackfromDB = await _context.Backgrounds.FindAsync(background.Id);

            

            if (background.Photo != null)
            {
                if (!background.Photo.isImage())
                {
                    ModelState.AddModelError("Photo", "file type is not valid");
                    return View(background);
                }
                if (!background.Photo.lessThan(2))
                {
                    ModelState.AddModelError("Photo", "file must be maximum 2 meqabites");
                    return View(background);
                }
                if (background.Photo.FileName.Contains("(")||background.Photo.FileName.Contains(" "))
                {
                    ModelState.AddModelError("Photo", "sekilin adinda  serti isareler olmali deyil ve bosluq olmali deyi");
                return View(background);
                }

                //remove old image and save new image
                RemoveImage(_env.WebRootPath, BackfromDB.Image);
                BackfromDB.Image = await background.Photo.SaveBackSlash(_env.WebRootPath, "BackGround");





            }



            BackfromDB.Title = background.Title;



            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }




    }
}