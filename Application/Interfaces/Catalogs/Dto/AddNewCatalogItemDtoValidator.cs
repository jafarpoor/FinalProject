using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Catalogs.Dto
{
  public  class AddNewCatalogItemDtoValidator : AbstractValidator<AddNewCatalogItemDto>
    {
       public AddNewCatalogItemDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("نام محصول اجباری است");
            RuleFor(p => p.Description).NotNull().WithMessage("توضیحات نمی تواند خالی باشد");
            RuleFor(p => p.Price).NotNull();


        }
    }
}
