
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MvcProject.Data
{
    public class  AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                

        }
        // to config the many to many relation  you need these steps to map the uniquly pk of Actor_Movie using lambda exp
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am =>new 
            {
                am.MovieId,
                am.ActorId
            });
            // to represent navigation property between the many to many relation
            modelBuilder.Entity<Actor_Movie>().HasOne(m=>m.Movie).WithMany(am=>am.Actor_Movies).HasForeignKey(m=>m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(a=>a.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(a => a.ActorId);
            base.OnModelCreating(modelBuilder);

        }
        // dbset is used to generate tables by code first then mapping them to database
        public DbSet<Actor>Actor{ get; set; }
       public DbSet<Actor_Movie> Actor_Movie { get; set; }

        public DbSet<Movie> Movie { get; set; }

        public DbSet<Cinema> Cinema { get; set; }

        public DbSet<Producer> Producer { get; set; }

    }
}
