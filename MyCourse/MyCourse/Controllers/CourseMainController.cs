using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCourse.Models;
using MyCourse.Data;
using Microsoft.Extensions.Hosting;
using MyCourse.Viewmodels;

namespace MyCourse.Controllers
{
    public class CourseMainController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly IHostEnvironment _env;

        public CourseMainController(ApplicationDbContext context, IHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        

        public IActionResult Index()
        {

            var vm = new HomeIndexVM();
            vm.Benefits = _context.Benefits.ToList().OrderByDescending(p => p.id);
            vm.Level = _context.Levels.ToList().OrderByDescending(p => p.Id);
            vm.background = _context.Backgrounds.ToList();
            vm.Abouts = _context.Abouts.ToList();
            return View( vm);

        }
    }
}