using Application.Dtos;
using Application.Interfaces.Contexts;
using Application.Interfaces.Payments;
using Domain.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Payments
{
    public class PaymentService : IPaymentService
    {
        private readonly IDataBaseContext context;
        private readonly IIdentityDatabaseContext identityContext;
        public PaymentService(IDataBaseContext context, IIdentityDatabaseContext identityDatabaseContext)
        {
            this.context = context;
            identityContext = identityDatabaseContext;
        }

        public PaymentDto GetPayment(Guid Id)
        {
            var payment = context.payments
                          .Include(p => p.Order)
                          .ThenInclude(p => p.OrderItems)
                          .SingleOrDefault(p => p.Id == Id);
            var user = identityContext.Users.SingleOrDefault(p => p.Id == payment.Order.UserId);
           
            string description = $"پرداخت سفارش شماره {payment.OrderId} " + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;

            foreach (var item in payment.Order.OrderItems.Select(p=>p.ProductName))
            {
                description += $"-{item}";
            }

            return new PaymentDto
            {
                Amount = payment.Order.TotalPrice(),
                Description = description,
                Email = user.Email,
                Id = payment.Id,
                PhoneNumber = user.PhoneNumber,
                Userid = user.Id
            };
        }

        public PaymentOfOrderDto PayForOrder(int OrderId)
        {
            var order = context.orders.SingleOrDefault(p=>p.Id == OrderId);
            if (order == null)
                throw new Exception("");
            var pay = context.payments.FirstOrDefault(p => p.OrderId == OrderId);
            if (pay == null)
                pay = new Payment(order.TotalPrice(), OrderId);
            context.payments.Add(pay);
            context.SaveChanges();

            return new PaymentOfOrderDto
            {
                Amount = pay.Amount,
                PaymentId = pay.Id,
                PaymentMethod = order.PaymentMethod
            };
        }

        public bool VerifyPayment(Guid Id, string Authority, long RefId)
        {
            throw new NotImplementedException();
        }
    }
}
