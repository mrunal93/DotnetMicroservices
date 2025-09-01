using System.Collections.Generic;
using System.Reflection;
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
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto coupon)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _couponService.CreateCouponasync(coupon);
                if (response != null && response.isSuuccess)
                   return RedirectToAction(nameof(CouponIndex));

            }
            return View(coupon);
        }
       
        public async Task<IActionResult> CouponDelete( int couponId)
        {
            ResponseDto? response = await _couponService.GetCouponBYIDasync( couponId);
            if (response != null && response.isSuuccess)
            {
                CouponDto? coupon = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
                return View(coupon);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CouponDelete(CouponDto coupon)
        {
            ResponseDto? response = await _couponService.DeleteCouponasync(coupon.CouponId);
            if (response != null && response.isSuuccess)
            {
                return RedirectToAction(nameof(CouponIndex));
            }
            return NotFound();
        }
    }
}
