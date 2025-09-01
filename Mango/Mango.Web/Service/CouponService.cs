using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Mango.Web.Service
{
    public class CouponService :ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService (IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto?> CreateCouponasync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> DeleteCouponasync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetAllCouponsasync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponasync(string couponId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> GetCouponBYIDasync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDto?> UpdateCouponasync(CouponDto couponDto)
        {
            throw new NotImplementedException();
        }
    }
}
