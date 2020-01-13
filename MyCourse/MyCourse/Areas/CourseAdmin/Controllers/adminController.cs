using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyCourse.Areas.CourseAdmin.Controllers
{
    [Area("CourseAdmin")]
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}