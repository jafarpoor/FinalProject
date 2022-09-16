using Application.Dtos;
using Application.Interfaces.Contexts;
using Application.Interfaces.Discounts;
using Common;
using Domain.Discounts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Discounts
{
    public class DiscountHistoryService : IDiscountHistoryService
    {
        private readonly IDataBaseContext _context;

        public DiscountHistoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public PaginatedItemsDto<DiscountUsageHistory> GetAllDiscountUsageHistory(int? discountId, string userId, int pageIndex, int pageSize)
        {
            var query = _context.discountUsageHistories.AsQueryable();
            if (discountId.HasValue && discountId.Value > 0)
                query = query.Where(p => p.DiscountId == discountId.Value);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(p => p.OrderId != null && p.Order.UserId == userId);

         var pagedItems = query.PagedResult(pageIndex, pageSize, out int rowCount);
         return new PaginatedItemsDto<DiscountUsageHistory>(pageIndex, pageSize, rowCount, query.ToList());

        }

        public DiscountUsageHistory GetDiscountUsageHistoryById(int discountUsageHistoryId)
        {
            if (discountUsageHistoryId == null)
                throw new Exception("");

            var result = _context.discountUsageHistories.Find(discountUsageHistoryId);
            return result;
        }

        public void InsertDiscountUsageHistory(int DiscountId, int OrderId)
        {
            var discount = _context.discounts.Find(DiscountId);
            var order = _context.orders.Find(OrderId);

            DiscountUsageHistory discountUsageHistory = new DiscountUsageHistory
            {
                Order = order,
                Discount = discount,
                CreatedOn = DateTime.Now

            };
            _context.discountUsageHistories.Add(discountUsageHistory);
            _context.SaveChanges();
        }
    }
}
