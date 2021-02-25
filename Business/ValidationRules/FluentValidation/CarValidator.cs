using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("Araç adı en az 2 karakter olmalı.");
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük fiyat değeri 0'dan büyük olmalı.");
        }
    }
}
