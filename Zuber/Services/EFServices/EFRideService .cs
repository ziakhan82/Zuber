using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zuber.Models;
using Zuber.Services.Interfaces;

namespace Zuber.Services.EFServices
{
    public class EFRideService:IRideService
    {
        ZuberDBContext service;
        public EFRideService(ZuberDBContext s)
        {
            service = s;
        }
        public void AddRide(Ride ride)
        {
            
            service.Rides.Add(ride);
            service.SaveChanges();
        }

        public void DeleteRide(int id)
        {
            service.Rides.Remove(GetRideById(id));
            service.SaveChanges();
        }
        public void UpdateRide(Ride ride)
        {
            service.Rides.Update(ride);
            service.SaveChanges();
        }

        public List<Ride> GetAllRides()
        {
            return service.Rides.ToList<Ride>();
        }


        public Ride GetRideById(int id)
        {
            return service.Rides.Where(x => x.Id == id).FirstOrDefault();
        }
        public Ride GetRideByUserId(int id)
        {
            return service.Rides.Where(x => x.DriverId == id).FirstOrDefault();
        }



    }
}
