using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Models
{
    public class Background
    {

        
        public int Id { get; set; }
        
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required (ErrorMessage ="Bu hisseni dolmasi vacibdir")]
        [StringLength(200,ErrorMessage ="tekstin uzunlugu maksimum 200 xarakter ola biler")]
        public string Title { get; set; }


    }
}
