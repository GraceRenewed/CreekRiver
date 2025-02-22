using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;
using System.Security.Principal;
using System.Net;
using System;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://cdn.crowdriff.com/in-use/fb121583-1300-95e0-ea35-466a02fc4438/375.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 2, Nickname = "The Roan", ImageUrl="https://threepeaksrvresort.com/wp-content/uploads/2024/05/350514462_244023234904092_79220620081563833_n.jpg"},
            new Campsite {Id = 3, CampsiteTypeId = 2, Nickname = "Natchez", ImageUrl="https://cdn.crowdriff.com/in-use/600287fc-d3a3-9967-14dc-a9db68a90bb0/375.jpg"},
            new Campsite {Id = 4, CampsiteTypeId = 3, Nickname = "Frozen Head", ImageUrl="https://cdn.crowdriff.com/in-use/e9bbf623-2b4a-0359-20bb-1ce4ae1158c4/375.jpg"},
            new Campsite {Id = 5, CampsiteTypeId = 4, Nickname ="Hiwassee", ImageUrl="https://cdn.crowdriff.com/in-use/d44b672a-1ea5-6697-1a02-7821470bf586/375.jpg"}
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Paul", LastName = "Bunyon", Email = "PaulB@gmail.com"}
        });
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 4, UserProfileId = 1, CheckinDate = new DateTime(2025,3,30), CheckoutDate = new DateTime(2025,4,1)},
            new Reservation {Id = 2, CampsiteId = 5, UserProfileId = 1, CheckinDate = new DateTime(2025,5,10), CheckoutDate = new DateTime(2025,5,15)}
        });

    }
}