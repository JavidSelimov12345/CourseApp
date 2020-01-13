using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace MyCourse.Models
{
    public class City
    {
        public City()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}
