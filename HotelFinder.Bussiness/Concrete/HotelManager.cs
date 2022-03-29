using HotelFinde.DataAccess.Abstract;
using HotelFinde.DataAccess.Concrete;
using HotelFinder.Business.Abstract;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<Hotel>  CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task Delete(int id)
        {
            await _hotelRepository.Delete(id);
        }

        public async Task<List<Hotel>>  GetAllHotels()
        {
            return await _hotelRepository.GetAllHotels();
        }
       
        public async Task<Hotel> GetHotelById(int id)
        {
            if (id>1)
            {
                return  await _hotelRepository.GetHotelById(id);
            }
            throw new Exception("id can not be less than 1");
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            return await _hotelRepository.Update(hotel);
        }

        
    }
}
