using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementInventory.ViewModels.Validators
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username Is Required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password Is Required");
        }
    }
}