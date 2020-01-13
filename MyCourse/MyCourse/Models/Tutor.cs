using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Models
{
    public class Tutor
    {

        public int Id { get; set; }

       
        
        public string image { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required (ErrorMessage ="bura mutleq dolmalodor")]
        [StringLength(200)]
        public string  date { get; set; }
        [Required (ErrorMessage ="bura mutleq durmalidir")]
        [StringLength(200)]
        public string Head { get; set; }
        [Required]
        [StringLength(200)]
        public string content { get; set; }



    }
}
