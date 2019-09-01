using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using WatchAuth.Models;

namespace WatchAuth.Managers
{
    public class DbManager
    {
        public ICollection<Actor> GetActors()
        {
            ICollection<Actor> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Actors.ToList();
            }
            return result;
        }

        public Actor GetActor(int id)
        {
            Actor result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Actors.Find(id);
            }
            return result;
        }

        public void AddActor(Actor actor)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Actors.Add(actor);
                db.SaveChanges();
            }
        }

        public void UpdateActor(Actor actor)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Actor db_actor = db.Actors.Find(actor.Id);
                // State of db_actor is unchanged
                db_actor.Name = actor.Name;
                db_actor.Age = actor.Age;
                db.SaveChanges();
            }
        }

        public void UpdateActor2(Actor actor)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Actors.Attach(actor);
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteActor(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Actor actor = db.Actors.Find(id);
                // 1st way
                db.Actors.Remove(actor);
                // 2nd way
                //db.Entry(actor).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public bool DeleteActorBool(int id)
        {
            bool result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Actor actor = db.Actors.Find(id);

                if (actor != null)
                {
                    // 1st way
                    db.Actors.Remove(actor);
                    // 2nd way
                    //db.Entry(actor).State = EntityState.Deleted;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public ICollection<Director> GetDirectors()
        {
            ICollection<Director> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Directors.ToList();
            }
            return result;
        }

        public Director GetDirector(int id)
        {
            Director result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Directors.Find(id);
            }
            return result;
        }

        public void AddDirector(Director director)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Directors.Add(director);
                db.SaveChanges();
            }
        }

        public void UpdateDirector(Director director)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Directors.Attach(director);
                db.Entry(director).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteDirector(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Director director = db.Directors.Find(id);
                // 1st way
                db.Directors.Remove(director);
                // 2nd way
                //db.Entry(director).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public ICollection<Category> GetCategories()
        {
            ICollection<Category> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Categories.ToList();
            }
            return result;
        }

        public Category GetCategory(string name)
        {
            Category result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Categories.Find(name);
            }
            return result;
        }

        public void AddCategory(Category category)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public void DeleteCategory(Category category)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Attach(category);
                db.Entry(category).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public void DeleteCategory(string name)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Category category = db.Categories.Find(name);
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }

        public ICollection<Movie> GetMovies()
        {
            ICollection<Movie> result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Movies.Include("Category")
                                  .Include("Director")
                                  .Include("Actors")
                                  .ToList();
            }
            return result;
        }

        public void AddMovie(Movie movie, List<int> actorIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                foreach (int id in actorIds)
                {
                    Actor actor = db.Actors.Find(id);
                    if (actor != null)
                    {
                        movie.Actors.Add(actor);
                    }
                }
                db.SaveChanges();
            }
        }

        public Movie GetMovie(int id)
        {
            Movie result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Movies.Find(id);
            }
            return result;
        }

        public Movie GetMovieFull(int id)
        {
            Movie result;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                result = db.Movies.Include("Category")
                                  .Include("Director")
                                  .Include("Actors")
                                  .Where(x => x.Id == id)
                                  .FirstOrDefault();
            }
            return result;
        }

        public void UpdateMovie(Movie movie, List<int> actorIds)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Movies.Attach(movie);
                db.Entry(movie).Collection("Actors").Load();
                movie.Actors.Clear();
                db.SaveChanges();
                foreach (int id in actorIds)
                {
                    Actor actor = db.Actors.Find(id);
                    if (actor != null)
                    {
                        movie.Actors.Add(actor);
                    }
                }
                db.SaveChanges();
            }
        }

        public void DeleteMovie(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Movie movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
                db.SaveChanges();
            }
        }
    }
}