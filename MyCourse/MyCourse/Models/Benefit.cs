using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Models
{
    public class Benefit
    {
        public int id { get; set; }

        [Required(ErrorMessage ="dolmalidir")]
        [StringLength(100,ErrorMessage ="100 xarakter olmalidir maximum")]
        public string number { get; set; }
        [StringLength(100, ErrorMessage = "100 xarakter olmalidir maximum")]
        [Required(ErrorMessage ="dolmalidir")]
        public string Content { get; set; }
    }
}
