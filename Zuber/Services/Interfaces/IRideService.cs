using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;

namespace Zuber.Services.Interfaces
{
    public interface IRideService
    {
        public void AddRide(Ride ride);
        public void UpdateRide(Ride ride);
        public void DeleteRide(int id);
        public List<Ride> GetAllRides();
        public Ride GetRideById(int id);
        public Ride GetRideByUserId(int id);
    }
}
