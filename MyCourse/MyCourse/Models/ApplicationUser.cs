using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        public string  Lastname { get; set; }

        public string Adress { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }


    }
}
