using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {

        private readonly ICouponService _couponService;

        public CouponController (ICouponService couponService)
        {
            _couponService = couponService;
        }
        public async Task< IActionResult > CouponIndex()
        {
            List<CouponDto>  List = new();
            ResponseDto? response = await _couponService.GetAllCouponsasync();
            if (response != null && response.isSuuccess)
                List = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));

            return View(List);
        }

        public async Task<IActionResult> CouponCreate()
        {
           
            return View();
        }
    }
}
