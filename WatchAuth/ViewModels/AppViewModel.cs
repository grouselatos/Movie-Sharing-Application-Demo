using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WatchAuth.Models;

namespace WatchAuth.ViewModels
{
    public enum SortOptions
    {
        Title = 1,
        Year = 2
    }
    public class AppViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<int> FavoriteMovies { get; set; }
        public string Search { get; set; }
        public string Category { get; set; }
        public SortOptions SortBy { get; set; }
    }
}