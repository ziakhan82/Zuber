using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zuber.Models;

namespace Zuber.Services.Interfaces
{
    public interface IDotService
    {
        public void AddDot(Dot dot);
        public void UpdateDot(Dot dot);
        public void DeleteDot(int id);
        public List<Dot> GetAllDots();
        public Dot GetDotById(int id);
        public Dot GetDotByUserId(int id);
    }
}
