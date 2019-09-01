using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WatchAuth.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vale kati nte!")]
        [MinLength(5, ErrorMessage = "Polu mikro onoma!")]
        public string Name { get; set; }

        [Range(1, 150, ErrorMessage = "Vale ena logiko orio ilikias!")]
        public int Age { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}