﻿using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MySeenWeb.Migrations;
using MySeenWeb.Models.Tables;
using MySeenWeb.Models.Tables.Portal;

namespace MySeenWeb.Models.OtherViewModels
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string UniqueKey { get; set; }
        public string Culture { get; set; }
        public DateTime RegisterDate { get; set; }
        public int RecordPerPage { get; set; }
        public int MarkersOnRoads { get; set; }
        public int EnableAnimation { get; set; }
        public string ShareTracksAllKey { get; set; }
        public string ShareTracksFootKey { get; set; }
        public string ShareTracksCarKey { get; set; }
        public string ShareTracksBikeKey { get; set; }
        public string ShareFilmsKey { get; set; }
        public string ShareSerialsKey { get; set; }
        public string ShareBooksKey { get; set; }
        public string ShareEventsKey { get; set; }
        public int Theme { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<IdentityUserLogin> UserLogins { get; set; }
        public IDbSet<IdentityUserRole> UserRoles { get; set; }
        public DbSet<Films> Films { get; set; }
        public DbSet<Serials> Serials { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<Bugs> Bugs { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Tracks> Tracks { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventsSkip> EventsSkip { get; set; }
        public DbSet<UserCredits> UserCredits { get; set; }
        public DbSet<NLogErrors> NLogErrors { get; set; }

        public DbSet<Memes> Memes { get; set; }
        public DbSet<MemesStats> MemesStats { get; set; }

        public DbSet<Realt> Realt { get; set; }
        public DbSet<Salary> Salary { get; set; }
        public DbSet<Deals> Deals { get; set; }

        public DbSet<Bots> Bots { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>("DefaultConnection"));
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}