namespace WatchAuth.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WatchAuth.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WatchAuth.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // Add Categories
            //Category cat_horror = new Category() { Name = "Horror" };
            //Category cat_scifi = new Category() { Name = "SciFi" };
            //Category cat_comedy = new Category() { Name = "Comedy" };
            //Category cat_western = new Category() { Name = "Western" };
            //Category cat_action = new Category() { Name = "Action" };
            //context.Categories.AddOrUpdate(x => x.Name, cat_horror);
            //context.Categories.AddOrUpdate(x => x.Name, cat_scifi);
            //context.Categories.AddOrUpdate(x => x.Name, cat_comedy);
            //context.Categories.AddOrUpdate(x => x.Name, cat_western);
            //context.Categories.AddOrUpdate(x => x.Name, cat_action);

            //// Add Directors
            //Director dir_tarantino = new Director() { Name = "Quentin Tarantino", Age = 56 };
            //Director dir_aronofsky = new Director() { Name = "Darren Aronofsky", Age = 50 };
            //Director dir_kubrick = new Director() { Name = "Stanley Kubrick", Age = 99 };
            //context.Directors.AddOrUpdate(x => x.Name, dir_tarantino);
            //context.Directors.AddOrUpdate(x => x.Name, dir_aronofsky);
            //context.Directors.AddOrUpdate(x => x.Name, dir_kubrick);

            //// Add Actors
            //Actor actor_travolta = new Actor() { Name = "John Travolta", Age = 52 };
            //Actor actor_ford = new Actor() { Name = "Harrison Ford", Age = 68 };
            //Actor actor_tom = new Actor() { Name = "Tom Cruz", Age = 51 };
            //context.Actors.AddOrUpdate(x => x.Name, actor_travolta);
            //context.Actors.AddOrUpdate(x => x.Name, actor_ford);
            //context.Actors.AddOrUpdate(x => x.Name, actor_tom);

            //context.SaveChanges();

            //// Add Movies
            //Movie movie_killbill = new Movie()
            //{
            //    Title = "Kill Bill",
            //    Year = 2003,
            //    Watched = false,
            //    Director = dir_tarantino,
            //    Category = cat_action
            //};
            //movie_killbill.Actors.Add(actor_travolta);
            //movie_killbill.Actors.Add(actor_ford);

            //Movie movie_fiction = new Movie()
            //{
            //    Title = "Pulp Fiction",
            //    Year = 1995,
            //    Watched = false,
            //    Director = dir_tarantino,
            //    Category = cat_action
            //};
            //movie_fiction.Actors.Add(actor_travolta);
            //movie_fiction.Actors.Add(actor_tom);

            //context.Movies.AddOrUpdate(x => x.Title, movie_killbill);
            //context.Movies.AddOrUpdate(x => x.Title, movie_fiction);

            //context.SaveChanges();
            
            //var userStore = new UserStore<ApplicationUser>(context);
            //ApplicationUserManager userManager = new ApplicationUserManager(userStore);
            //var roleStore = new RoleStore<IdentityRole>(context);
            //RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

            //string email = "admin@gmail.com";
            //string username = "admin";
            //string password = "iamtheadmin";
            //string roleName = "Admin";

            //IdentityRole role = roleManager.FindByName(roleName);
            //if (role == null)
            //{
            //    role = new IdentityRole(roleName);
            //    roleManager.Create(role);
            //}

            //ApplicationUser user = userManager.FindByName(username);
            //if (user == null)
            //{
            //    user = new ApplicationUser() { UserName = email, Email = email };
            //    userManager.Create(user, password);
            //}

            //if(!userManager.IsInRole(user.Id, role.Name)) {
            //    userManager.AddToRole(user.Id, role.Name);
            //}
        }
    }
}
