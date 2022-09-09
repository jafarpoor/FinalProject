using Application.Interfaces.Payments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarinPal.Class;
using Microsoft.Extensions.Configuration;
using WebSite.EndPoint.Utilities;
using Dto.Payment;
using RestSharp;
using Application.Dtos;
using Newtonsoft.Json;

namespace WebSite.EndPoint.Controllers
{
    public class PayController : Controller
    {
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        private readonly string merchendId;


        private readonly IConfiguration configuration;
        private readonly IPaymentService paymentService;

        public PayController(IConfiguration configuration, IPaymentService paymentService)
        {
            this.configuration = configuration;
            this.paymentService = paymentService;
            merchendId = configuration["ZarinpalMerchendId"];


            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();

        }


        public async Task<IActionResult> Index(Guid paymentId)
        {
            var payment = paymentService.GetPayment(paymentId);
            if (payment == null)
                NotFound();
            if (payment.Userid != ClaimUtility.GetUserId(User))
                return BadRequest();


            string callBackUrl = Url.Action(nameof(Verify), "pay", new { payment.Id }, protocol: Request.Scheme);

            var reasultZarinpall = await _payment.Request(new DtoRequest
            {
                Amount = payment.Amount,
                CallbackUrl = callBackUrl,
                Description = payment.Description,
                Email = payment.Email,
                MerchantId = merchendId,
                Mobile = payment.PhoneNumber,
            }, Payment.Mode.zarinpal);
            return View();

            return Redirect($"https://zarinpal.com/pg/StartPay/{reasultZarinpall.Authority}");
        }

        public IActionResult Verify(Guid Id, string Authority)
        {
            string Status = HttpContext.Request.Query["Status"];
            if (Status != "" && Status.ToString().ToLower() == "ok"
              && Authority != "")
            {
                var payment = paymentService.GetPayment(Id);
                if (payment == null)
                {
                    return NotFound();
                }

                //var verification = _payment.Verification(new DtoVerification
                //{
                //    Amount = payment.Amount,
                //    Authority = Authority,
                //    MerchantId = merchendId,
                //}, Payment.Mode.zarinpal).Result;

                var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{payment.Amount}\"}}", ParameterType.RequestBody);
                var response = client.Execute(request);

                VerificationPayResultDto verification =
                    JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);

                if (verification.Status == 100)
                {
                    bool verifyResult = paymentService.VerifyPayment(Id, Authority, verification.RefID);
                    if (verifyResult)
                    {
                        return Redirect("/customers/orders");
                    }
                    else
                    {
                        TempData["message"] = "پرداخت انجام شد اما ثبت نشد";
                        return RedirectToAction("checkout", "basket");
                    }
                }
                else
                {
                    TempData["message"] = "پرداخت شما ناموفق بوده است . لطفا مجددا تلاش نمایید یا در صورت بروز مشکل با مدیریت سایت تماس بگیرید .";
                    return RedirectToAction("checkout", "basket");
                }

            }
            TempData["message"] = "پرداخت شما ناموفق بوده است .";
            return RedirectToAction("checkout", "basket");
        }


        }
   }

