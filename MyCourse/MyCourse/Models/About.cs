using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Models
{
    public class About
    {


        public int Id { get; set; }


        public string Images { get; set; }

        [NotMapped]
        public IFormFile  Photo { get; set; }


        [Required(ErrorMessage =("doldurulmasi mutleqdir"))]
        [StringLength(200,ErrorMessage =("maximum 200 xarakter ola biler"))]
        public string Header { get; set; }

        [Required(ErrorMessage = ("doldurulmasi mutleqdir"))]
        [StringLength(200, ErrorMessage = ("maximum 200 xarakter ola biler"))]
        public string BoldWord { get; set; }

        [Required(ErrorMessage = ("doldurulmasi mutleqdir"))]
        [StringLength(200, ErrorMessage = ("maximum 200 xarakter ola biler"))]
        public string TitleOne { get; set; }


        [Required(ErrorMessage = ("doldurulmasi mutleqdir"))]
        [StringLength(200, ErrorMessage = ("maximum 200 xarakter ola biler"))]
        public string TitleTwo { get; set; }


        [Required(ErrorMessage = ("doldurulmasi mutleqdir"))]
        [StringLength(200, ErrorMessage = ("maximum 200 xarakter ola biler"))]
        public string TitleThree { get; set; }

    }
}
