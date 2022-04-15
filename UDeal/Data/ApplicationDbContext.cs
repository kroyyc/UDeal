using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UDeal.Models;

namespace UDeal.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<Selling> SellingPosts { get; set; }
        //public DbSet<Looking> LookingPosts { get; set;}
        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Favourite> UserFavourites { get; set; } 
        public DbSet<Image> Images { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(b => b.ToTable("Users"));
            modelBuilder.Entity<IdentityRole>(b => b.ToTable("Roles"));
            modelBuilder.Entity<IdentityUserRole<string>>(b => b.ToTable("UserRoles"));

            modelBuilder.Entity<Favourite>().HasKey(o => new { o.UserId, o.PostId });
            modelBuilder.Entity<Post>()
                .Property(p => p.Created)
                .HasDefaultValueSql("datetime('now','localtime')");

            // If admin removes a campus, set posts with that camnpus to null
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Campus)
                .WithMany(c => c.Posts)
                .HasForeignKey(c => c.CampusId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // If a course is removed from db, set posts with that course to null
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Course)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CourseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // If admin removes a school, all its users should be revoked
            modelBuilder.Entity<User>()
                .HasOne(u => u.School)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.SchoolId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            // If admin removes a campus, don't assume it's users access should be revoked
            modelBuilder.Entity<User>()
                .HasOne(u => u.Campus)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CampusId)
                .IsRequired(false)  // admin doesnt attend a school, thus no campus
                .OnDelete(DeleteBehavior.SetNull);
            
            // If a user is removed from the db, all their posts need to be wiped as well
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            // If a user is remopved from the db, also remove their contact info entry
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.User)
                .WithOne(u => u.Contact)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();
        }
    }
}
