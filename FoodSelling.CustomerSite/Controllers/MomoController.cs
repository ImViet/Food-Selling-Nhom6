using FoodSelling.CustomerSite.Extensions;
using FoodSelling.CustomerSite.Interfaces;
using FoodSelling.DTO.Dtos.CustomerSite.MomoDtos;
using FoodSelling.DTO.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FoodSelling.CustomerSite.Controllers
{
    public class MomoController: Controller
    {
        private readonly ICart _cartService;
        private readonly IAuth _authService;
        public MomoController(ICart cartService, IAuth authService)
        {
            _cartService = cartService;
            _authService = authService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Payment()
        {
            var cart = _cartService.GetCart();
            var totalCash = cart.Sum(p => p.Total);
            var userQuery = await _authService.GetMe(HttpContext.Session?.GetString("UserName"));
            var user = userQuery.Name;
            //request params need to request to MoMo system
            string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "Thanh toán đơn hàng " + orderid + " cho " + user;
            string returnUrl = "https://localhost:7059/ConfirmPaymentClient";
            string notifyurl = "https://localhost:7059/Home/SavePayment"; 

            string amount = totalCash.ToString();
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);
           
            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };
           
            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);
            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

//Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
//errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        // public ActionResult ConfirmPaymentClient(MomoResult result)
        // {
        //     //lấy kết quả Momo trả về và hiển thị thông báo cho người dùng (có thể lấy dữ liệu ở đây cập nhật xuống db)
        //     string rMessage  = result.message;
        //     string rOrderId = result.orderId;
        //     string rErrorCode = result.errorCode; // = 0: thanh toán thành công
        //     if(rErrorCode == "0")
        //     {
        //         HttpContext.Session.Remove("Cart");
        //         HttpContext.Session.Remove("CountCart");
        //     }
        //     return View();
        // }
        // [HttpPost]
        // public void SavePayment()
        // {
        //     //cập nhật dữ liệu vào db
        //     String a = "";
        // }
    }
}