using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyCourse.Data;



namespace MyCourse.Controllers
{

   
    public class TutorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TutorsController(ApplicationDbContext context)
        {
            _context = context;
        }
       
       

       
        public IActionResult Index()
        {
            return View(_context.Tutors.ToList().OrderByDescending(p=>p.Id));
        }
    }
}