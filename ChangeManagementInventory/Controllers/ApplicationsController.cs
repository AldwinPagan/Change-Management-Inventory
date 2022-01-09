using ChangeManagementInventory.Models;
using ChangeManagementInventory.ViewModels;
using ChangeManagementInventory.ViewModels.Validators;
using PagedList;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.Controllers
{
    //[ADAuth]
    public class ApplicationsController : Controller
    {
        private readonly ApplicationRepository _applicationRepository;
        private readonly AppTypeRepository _appTypeRepository;
        private readonly AppLicenseTypeRepository _appLicenseTypeRepository;
        private readonly CompanyRepository _companyRepository;
        public ApplicationsController()
        {
            _applicationRepository = new ApplicationRepository();
            _appTypeRepository = new AppTypeRepository();
            _appLicenseTypeRepository = new AppLicenseTypeRepository();
            _companyRepository = new CompanyRepository();

        }
        // /Applications
        public ActionResult Index(int page = 1,
            int pageSize = 5,
            String ApplicationName = "",
            String SupplierName = "",
            String SelectedAppTypeId = ""
            )
        {

            var AppTypeId = String.IsNullOrEmpty(SelectedAppTypeId) ? Guid.Empty : Guid.Parse(SelectedAppTypeId);
            var applications = _applicationRepository.GetApplicationsByNameAndSupplierNameAndAppType(
                    ApplicationName.Trim(),
                    SupplierName.Trim(),
                    AppTypeId
                    ).ToList();

            var model = new PagedList<Application>(applications, page, pageSize);
            pageSize = pageSize < 1 || pageSize > 5 ? 1 : pageSize;
            var viewModel = new ApplicationsViewModel
            {
                Applications = model,
                AppTypes = _appTypeRepository.GetAppTypesDropdown(),
                ApplicationName = ApplicationName.Trim(),
                SupplierName = SupplierName.Trim(),
                SelectedAppTypeId = SelectedAppTypeId
            };

            return View(viewModel);
        }


        [HttpGet]
        public ActionResult Application(Guid? id)
        {
            var application = new Application();
            if (id.HasValue)
            {
                application = _applicationRepository.GetApplicationById(id.Value);
            }

            var model = toViewModel(application);
            return View(model);
        }


        [HttpPost]
        public HttpStatusCodeResult Delete(Guid Id)
        {
            _applicationRepository.Delete(Id);
            return new HttpStatusCodeResult(200);
        }


        [HttpPost]
        public ActionResult Application(ApplicationViewModel model,
                    HttpPostedFileBase UserManualFile,
                    HttpPostedFileBase OpsManualFile,
                    HttpPostedFileBase DBManualFile,
                    Guid? Id)
        {
            var application = toModel(model, Id);
            var validator = new ApplicationViewModelValidator();
            var result = validator.Validate(model);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                application.Id = String.IsNullOrEmpty(model.Id) ? Guid.Empty : Guid.Parse(model.Id);
                var viewModel = toViewModel(application);
                return View(viewModel);
            }

            if (DBManualFile != null)
            {
                var databaseManual = Manual.Create(ManualType.Database, DBManualFile);
                application.DBManualPath = databaseManual.FilePath;
                databaseManual.Save();

            }
            if (OpsManualFile != null)
            {
                var operationsManual = Manual.Create(ManualType.Operation, OpsManualFile);
                application.OpsManualPath = operationsManual.FilePath;
                operationsManual.Save();
            }


            if (UserManualFile != null)
            {
                var userManual = Manual.Create(ManualType.User, UserManualFile);
                application.UserManualPath = userManual.FilePath;
                userManual.Save();
            }

            _applicationRepository.Save(application);
            return RedirectToAction("Index");
        }

        private ApplicationViewModel toViewModel(Application application)
        {
            var viewModel = new ApplicationViewModel
            {
                Application = application,
                AppTypes = _appTypeRepository.GetAppTypesDropdown(application.AppTypeId),
                Suppliers = _companyRepository.GetSuppliersDropdown(application.SupplierId),
                Manufacturers = _companyRepository.GetManufacturersDropdown(application.ManufacturerId),
                AppLicenseTypes = _appLicenseTypeRepository.GetAppLicenseTypesDropdown(application.AppLicenseTypeId),
                DBManualFileName = String.IsNullOrEmpty(application.DBManualPath) ? null : _applicationRepository.GetFileName(application.DBManualPath),
                OpsManualFileName = String.IsNullOrEmpty(application.OpsManualPath) ? null : _applicationRepository.GetFileName(application.OpsManualPath),
                UserManualFileName = String.IsNullOrEmpty(application.UserManualPath) ? null : _applicationRepository.GetFileName(application.UserManualPath)
            };
            return viewModel;
        }

        private Application toModel(ApplicationViewModel applicationViewModel, Guid? Id)
        {

            var model = new Application()
            {
                Id = Id.HasValue ? Id.Value: Guid.NewGuid(),
                Abbreviation = applicationViewModel.Abbreviation,
                AppTypeId = Guid.Parse(applicationViewModel.SelectedAppTypeId),
                AppSupportTime = applicationViewModel.AppSupportTime,
                AppLicenseTypeId = Guid.Parse(applicationViewModel.SelectedAppLicenseTypeId),
                Description = applicationViewModel.Description,
                HighAvailable = applicationViewModel.HighAvailable,
                IsActive = applicationViewModel.IsActive,
                ManufacturerId = Guid.Parse(applicationViewModel.SelectedManufacturerId),
                Name = applicationViewModel.Name,
                NeedADAuthentication = applicationViewModel.NeedADAuthentication,
                Support = applicationViewModel.Support,
                SupplierId = Guid.Parse(applicationViewModel.SelectedSupplierId),
                UseProcesses = applicationViewModel.UseProcesses,
                Version = applicationViewModel.Version
            };
            return model;
        }
    }
}