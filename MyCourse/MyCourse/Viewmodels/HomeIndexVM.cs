using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyCourse.Models;

namespace MyCourse.Viewmodels
{
    public class HomeIndexVM
    {
        public IEnumerable<Level> Level { get; set; }

        public IEnumerable<Benefit> Benefits { get; set; }

        public IEnumerable<Background> background { get; set; }

        public List<About> Abouts { get; set; }
    }
}
