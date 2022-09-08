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
                return View();
            }
        }
    }
}
