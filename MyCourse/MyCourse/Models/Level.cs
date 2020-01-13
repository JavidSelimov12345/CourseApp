using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Models
{
    public class Level
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Burani mutleq doldur")]
        [StringLength(100,ErrorMessage ="uzunluq 100 xarakterden artiq ola bilmez")]
        public string Header { get; set; }

        [Required(ErrorMessage ="Burani mutleq doldur")]
        [StringLength(200,ErrorMessage ="uzunluq 200 xarakterden cox olmali deyil")]
        public string Content { get; set; }


    }
}
