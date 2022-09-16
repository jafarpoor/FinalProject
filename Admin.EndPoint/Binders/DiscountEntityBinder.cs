using Application.Dtos;
using MD.PersianDateTime.Standard;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.EndPoint.Binders
{
    public class DiscountEntityBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            string FieldName = bindingContext.FieldName;

            AddNewDiscountDto discount = new AddNewDiscountDto() {

                CouponCode = bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.CouponCode)}").Values.ToString() ,

                DiscountAmount = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discount.DiscountAmount)}").Values.ToString()) ,
                DiscountLimitationId = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discount.DiscountLimitationId)}").Values.ToString()) ,
                DiscountPercentage = int.Parse(bindingContext.ValueProvider.GetValue($"{FieldName}.{nameof(discount.DiscountPercentage)}").Values.ToString()),
                DiscountTypeId = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.DiscountTypeId)}").Values.ToString()),
                LimitationTimes = int.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.LimitationTimes)}").Values.ToString()),

                UsePercentage = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.UsePercentage)}").FirstValue.ToString()),

                Name = bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.Name)}").Values.ToString(),

                RequiresCouponCode = bool.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.RequiresCouponCode)}").FirstValue.ToString()),

                EndDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.EndDate)}").Values.ToString()),

                StartDate = PersianDateTime.Parse(bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.StartDate)}").Values.ToString()),
            };

            var appliedToCatalogItem = bindingContext.ValueProvider.GetValue("model.appliedToCatalogItem");

            if (!string.IsNullOrEmpty(appliedToCatalogItem.Values))
            {
                discount.appliedToCatalogItem =
                bindingContext.ValueProvider
                .GetValue($"{FieldName}.{nameof(discount.appliedToCatalogItem)}")
                .Values.ToString().Split(',').Select(x => Int32.Parse(x)).ToList();
            }

            bindingContext.Result = ModelBindingResult.Success(discount);
            return Task.CompletedTask;

        }
    }
}
