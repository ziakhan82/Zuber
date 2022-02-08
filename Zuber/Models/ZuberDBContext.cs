using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zuber.Models
{
    public class ZuberDBContext:DbContext
    {
        public ZuberDBContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<ZuberUser> Users { get; set; }
        public virtual DbSet<Dot> Dots { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
    }
}
