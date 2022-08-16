using Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Orders
{
   public interface IOrderService
    {
        int CreateOrder(int BasketId, int UserAddressId, PaymentMethod paymentMethod);

    }
}
