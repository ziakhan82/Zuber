using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using Zuber.Models;
using Zuber.Services.EFServices;
using Zuber.Services.Interfaces;

namespace ZuberTest
{
    public class UnitTest:TestDataService
    {
        ZuberDBContext Context { get; set; }
        IDotService dotService { get; set; }
        IRideService rideService { get; set; }
        IUserService userService { get; set; }
        public UnitTest():base(new DbContextOptionsBuilder<ZuberDBContext>().UseInMemoryDatabase("Filename=Test.db").Options)
        {
            Context = new ZuberDBContext(ContextOptions);
            dotService = new EFDotService(Context);
            rideService = new EFRideService(Context);
            userService = new EFUserService(Context);
        }
        [Fact]
        public void TestUserGetAll()
        {
            var users = userService.GetAllUsers();
            Assert.Equal(3,users.Count);
            var dots = dotService.GetAllDots();
            Assert.Equal(3, dots.Count);
            var rides = rideService.GetAllRides();
            Assert.Single(rides);
            Assert.Equal(1, users[0].Id);
            Assert.Equal(2, dots[0].Id);
            Assert.Equal(1, rides[0].Id);
            Assert.Equal(3, users[2].Id);
            Assert.Equal(4, dots[2].Id);

        }
        [Fact]
        public void TestAdd()
        {
            userService.AddZuberUser(new ZuberUser() { Id = 4, Name = "Horhe", Email = "hoh@gmail.cmo", PhoneNo = "666666766", Password = "asdf", Driver = true, DotId = 5 });
            dotService.AddDot(new Dot() { Id = 5, Lat = 55.62574612055017, Long = 12.077345357900159, Description = "NEVER GONNA GIVE YOU UP", Hidden = false, ZuberUserID = 4 });
            rideService.AddRide(new Ride(){ Id = 2, PlacesRemaining = 1, DriverId = 4, CarDescription = "it's a bike lol" });
            var users = userService.GetAllUsers();  
            Assert.Equal(4, users.Count);
            var dots = dotService.GetAllDots();
            Assert.Equal(4, dots.Count);
            var rides = rideService.GetAllRides();
            Assert.Equal(2, rides.Count);
            Assert.Equal(1, users[0].Id);
            Assert.Equal(2, dots[0].Id);
            Assert.Equal(1, rides[0].Id);
            Assert.Equal(4, users[3].Id);
            Assert.Equal(5, dots[3].Id);
            Assert.Equal(2, rides[1].Id);
        }
        [Fact]
        public void TestUpdate()
        {
            userService.UpdateZuberUser(new ZuberUser() { Id = 2, Name = "Horhe", Email = "hoh@gmail.cmo", PhoneNo = "666666766", Password = "asdf", Driver = true, DotId = 3 });
            dotService.UpdateDot(new Dot() { Id = 3, Lat = 55.62574612055017, Long = 12.077345357900159, Description = "NEVER GONNA GIVE YOU UP", Hidden = false, ZuberUserID = 2 });
            rideService.UpdateRide(new Ride() { Id = 1, PlacesRemaining = 1, DriverId = 2, CarDescription = "it's a bike lol" });
            var users = userService.GetAllUsers();
            Assert.Equal(3, users.Count);
            var dots = dotService.GetAllDots();
            Assert.Equal(3, dots.Count);
            var rides = rideService.GetAllRides();
            Assert.Single(rides);
            Assert.Equal(1, users[0].Id);
            Assert.Equal(2, dots[0].Id);
            Assert.Equal(1, rides[0].Id);
            Assert.Equal("Horhe", users[1].Name);
            Assert.Equal("NEVER GONNA GIVE YOU UP", dots[1].Description);
            Assert.Equal(1, rides[0].PlacesRemaining); ;

        }
        [Fact]
        public void TestDelete()
        {
            dotService.DeleteDot(3);
            var users = userService.GetAllUsers();
            Assert.Equal(3, users.Count);
            var dots = dotService.GetAllDots();
            Assert.Equal(2, dots.Count);
            var rides = rideService.GetAllRides();
            Assert.Single(rides);
            rideService.DeleteRide(1);
            users = userService.GetAllUsers();
            Assert.Equal(3, users.Count);
            dots = dotService.GetAllDots();
            Assert.Equal(2, dots.Count);
            rides = rideService.GetAllRides();
            Assert.Empty(rides);
            userService.DeleteZuberUser("toni@gmail.com");
            users = userService.GetAllUsers();
            Assert.Equal(2, users.Count);
            dots = dotService.GetAllDots();
            Assert.Equal(2, dots.Count);
            rides = rideService.GetAllRides();
            Assert.Empty(rides);
            Assert.Equal(1, users[0].Id);
            Assert.Equal(2, dots[0].Id);
            Assert.Equal(3, users[1].Id);
            Assert.Equal(4, dots[1].Id);
        }
    }
}
