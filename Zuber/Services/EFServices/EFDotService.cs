using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;
using Zuber.Services.Interfaces;

namespace Zuber.Services.EFServices
{
    public class EFDotService:IDotService
    {
        ZuberDBContext service;
        public EFDotService(ZuberDBContext s)
        {
            service = s;
        }
        public void AddDot(Dot dot)
        {
            service.Dots.Add(dot);
            service.SaveChanges();
        }

        public void DeleteDot(int id)
        {
            service.Dots.Remove(GetDotById(id));
            service.SaveChanges();
        }
        public void UpdateDot(Dot dot)
        {
            service.Dots.Update(dot);
            service.SaveChanges();
        }

        public List<Dot> GetAllDots()
        {
            return service.Dots.Include(d=>d.ZuberUser).Include(d=>d.ZuberUser.Ride).ToList<Dot>();
        }

        public Dot GetDotByUserId(int id)
        {
            return service.Dots.Where(x => x.ZuberUserID == id).FirstOrDefault();
        }

        public Dot GetDotById(int id)
        {
            return service.Dots.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
