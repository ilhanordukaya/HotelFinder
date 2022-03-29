using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }


        /// <summary>
        /// Get all hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);//200+ data

        }

        /// <summary>
        /// get hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult>  GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);

            if (hotel!=null)
            {
                return  Ok(hotel);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetHotelByName(string name)
        {
            var hotel =await _hotelService.GetHotelByName(name);

            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }
        /// <summary>
        /// create an hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateTheHotel([FromBody]Hotel hotel)
        {
            var createdHotel = await _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get",new { id=createdHotel.Id},createdHotel);

        }
        /// <summary>
        /// update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateTheHotel([FromBody] Hotel hotel)
        {

            if ( await _hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok( await _hotelService.Update(hotel));
            }
            return BadRequest();

        }
        /// <summary>
        /// delete the hotel
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Route("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _hotelService.GetHotelById(id)!=null)
            {
               await _hotelService.Delete(id);
                return Ok();
            }
            return BadRequest();
        }
    }

}