using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelFinde.DataAccess
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-9VC8NQTV\\SQLEXPRESS; Database=HotelDb;Integrated Security=True");
        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
