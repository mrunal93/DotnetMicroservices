using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            _responseDto = new ResponseDto();   
        }

        [HttpGet]

        public ResponseDto Get()
        {
            try
            {

                IEnumerable<Coupon> objectList = _db.Coupones.ToList();
               _responseDto.Result = objectList;
            }
            catch (Exception ex) {

                _responseDto.isSuuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {

                Coupon objectList = _db.Coupones.First(u => u.CouponId == id);
                _responseDto.Result = objectList;
            }
            catch (Exception ex) {
                    _responseDto.isSuuccess = false;
                    _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
