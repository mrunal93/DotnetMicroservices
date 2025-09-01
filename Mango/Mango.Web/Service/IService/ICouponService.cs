using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {

        Task<ResponseDto?> GetCouponasync(string couponId);
        Task<ResponseDto?> GetAllCouponsasync();
        Task<ResponseDto?> GetCouponBYIDasync(int ID);
        Task<ResponseDto?> CreateCouponasync(CouponDto couponDto);
        Task<ResponseDto?> UpdateCouponasync(CouponDto couponDto);
        Task<ResponseDto?> DeleteCouponasync(int ID);
    }
}