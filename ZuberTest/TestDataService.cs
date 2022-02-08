using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Zuber.Models;

namespace ZuberTest
{
    public class TestDataService
    {
        protected DbContextOptions<ZuberDBContext> ContextOptions { get; }
        protected TestDataService(DbContextOptions<ZuberDBContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();

        }
        private void Seed()
        {
            using (var context = new ZuberDBContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Users.Add(new ZuberUser() {Id=1,Name="Pedro",Email="pedro@gmail.com",PhoneNo="12345678",Password="asdf",Driver=false, DotId=2});
                context.Users.Add(new ZuberUser() { Id = 2, Name = "Toni", Email = "toni@gmail.com", PhoneNo = "87654321", Password = "asdf", Driver = true, DotId = 2,RideId=1 });
                context.Users.Add(new ZuberUser() { Id = 3, Name = "Catalina", Email = "cata@gmail.com", PhoneNo = "666666666", Password = "asdf", Driver = false, DotId = 2 });
                context.Dots.Add(new Dot() { Id = 2, Lat = 55.645518273899739, Long = 12.084714869877802, Description = "pick me up on klostervang pls", Hidden = false, ZuberUserID = 1 });
                context.Dots.Add(new Dot() { Id = 3, Lat = 55.65054072652709 , Long = 12.091409367317672, Description = "driving from Kund den stores vej", Hidden = false, ZuberUserID = 2 });
                context.Dots.Add(new Dot() { Id = 4, Lat = 55.63691923296522,  Long = 12.040578986958714, Description = "hyrdehøj", Hidden = false, ZuberUserID = 3 });
                context.Rides.Add(new Ride() { Id = 1, PlacesRemaining = 3, DriverId = 2, CarDescription = "yellow opel" });
                context.SaveChanges();
            }
        }
    }
}
