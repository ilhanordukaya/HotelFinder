using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinde.DataAccess.Abstract
{
   public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();
        Task<Hotel>   GetHotelById(int id);
        Task<Hotel> GetHotelByName(string name);
        Task<Hotel> CreateHotel(Hotel hotel);
        Task<Hotel> Update(Hotel hotel);
        Task Delete(int id);
    }
}
