using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using WatchAuth.Models;
using WatchAuth.ViewModels;

namespace WatchAuth.Managers
{
    public class AppManager
    {
        public ICollection<Movie> GetMovies(string search, string category, int sortBy)
        {
            List<Movie> result;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                var query = db.Movies.AsQueryable();
                if (!String.IsNullOrEmpty(search))
                {
                    query = query.Where(x => x.Title.Contains(search));
                }
                if (!String.IsNullOrEmpty(category))
                {
                    query = query.Where(x => x.Genre == category);
                }
                switch((SortOptions)sortBy)
                {
                    case SortOptions.Title:
                        query = query.OrderBy(x => x.Title);
                        break;
                    case SortOptions.Year:
                        query = query.OrderBy(x => x.Year);
                        break;
                }
                result = query.ToList();
            }
            return result;
        }

        public ICollection<int> GetFavoriteMovies(string userId)
        {
            ICollection<int> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // Not a good implementation. Can throw null exception.
                result = db.Users.Include(x => x.FavoriteMovies)
                                 .Where(x => x.Id == userId)
                                 .FirstOrDefault()
                                 .FavoriteMovies
                                 .Select(x => x.Id)
                                 .ToList();                      
            }
            return result;
        }
        public ICollection<Category> GetCategories()
        {
            List<Category> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Categories.ToList();
            }
            return result;
        }
        public bool ToggleFavoriteMovie(int movieId, string userId)
        {
            bool result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                ApplicationUser user = db.Users.Include(x => x.FavoriteMovies)
                                               .Where(x => x.Id == userId)
                                               .FirstOrDefault();
                Movie movie = user.FavoriteMovies.Where(x => x.Id == movieId)
                                                 .FirstOrDefault();
                if (movie == null)
                {
                    movie = db.Movies.Find(movieId);
                    user.FavoriteMovies.Add(movie);
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    user.FavoriteMovies.Remove(movie);
                    db.SaveChanges();
                    result = false;
                }
            }
            return result;
        }
    }
}