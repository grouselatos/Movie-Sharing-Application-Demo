using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WatchAuth.Models
{
    public class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            FavoredBy = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Full Title of Movie")]
        public string Title { get; set; }
        public int Year { get; set; }
        public bool Watched { get; set; }

        [ForeignKey("Category")]
        public string Genre { get; set; }
        public virtual Category Category { get; set; }
        [DisplayName("Director")]
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }

        public virtual ICollection<ApplicationUser> FavoredBy { get; set; }
    }
}