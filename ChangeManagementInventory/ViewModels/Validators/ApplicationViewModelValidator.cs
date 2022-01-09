using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementInventory.ViewModels.Validators
{

    public class ApplicationViewModelValidator : AbstractValidator<ApplicationViewModel>
    {
        public ApplicationViewModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Abbreviation).NotEmpty();

            RuleFor(x => x.Version).NotEmpty();

            RuleFor(x => x.SelectedAppLicenseTypeId)
                .NotEqual(Guid.Empty.ToString())
                .WithMessage("An 'Application License Type' must be selected");

            RuleFor(x => x.SelectedAppTypeId)
                .NotEqual(Guid.Empty.ToString())
                .WithMessage("An 'Application Type' must be selected");

            RuleFor(x => x.SelectedManufacturerId)
                .NotEqual(Guid.Empty.ToString())
                .WithMessage("A 'Manufacturer' must be selected");

            RuleFor(x => x.SelectedSupplierId)
                .NotEqual(Guid.Empty.ToString())
                .WithMessage("A 'Supplier' must be selected");

            RuleFor(x => x.AppSupportTime).NotEmpty();
        }
    }
}