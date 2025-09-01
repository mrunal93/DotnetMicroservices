using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();   
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {

                IEnumerable<Coupon> objectList = _db.Coupones.ToList();
               _responseDto.Result =_mapper.Map<IEnumerable<CouponDto>>(objectList);
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
                _responseDto.Result = _mapper.Map<CouponDto>(objectList);
            }
            catch (Exception ex) {
                    _responseDto.isSuuccess = false;
                    _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto Get(string code)
        {
            try
            {

                Coupon objectList = _db.Coupones.First(u => u.CouponCode.ToLower() == code.ToLower());
                

                _responseDto.Result = _mapper.Map<CouponDto>(objectList);
            }
            catch (Exception ex)
            {
                _responseDto.isSuuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
        
        public ResponseDto Create([FromBody] CouponDto couponDto)
        {
            try
            {

                Coupon createcoupon = _mapper.Map<Coupon>(couponDto);

                _db.Coupones.Add(createcoupon);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(createcoupon);
            }
            catch (Exception ex)
            {
                _responseDto.isSuuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]

        public ResponseDto UpdateCoupon([FromBody] CouponDto couponDto)
        {
            try
            {

                Coupon createcoupon = _mapper.Map<Coupon>(couponDto);

                _db.Coupones.Update(createcoupon);
                _db.SaveChanges();

                _responseDto.Result = _mapper.Map<CouponDto>(createcoupon);
            }
            catch (Exception ex)
            {
                _responseDto.isSuuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ResponseDto DeleteCoupon(int Id)
        {
            try
            {

                Coupon deleteCoupons = _db.Coupones.First(u => u.CouponId == Id);

                _db.Coupones.Remove(deleteCoupons);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                _responseDto.isSuuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
