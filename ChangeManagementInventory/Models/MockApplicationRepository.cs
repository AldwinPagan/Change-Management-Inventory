using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementInventory.Models
{
    public class MockApplicationRepository : IApplicationRepository
    {
        private readonly IAppLicenseTypeRepository _appLicenseTypeRepository = new MockAppLicenseTypeRepository();
        private readonly IAppTypeRepository _appTypeRepository = new MockAppTypeRepository();
        private readonly ICompanyRepository _companyRepository = new MockCompanyRepository();
        public ICollection<Application> GetApplications =>
            new List<Application>
            {
                new Application
                {
                    Id = new Guid("c3c20b35-9c3c-4b81-9bbc-7087aecd628e"),
                    Abbreviation = "AA",
                    AppSupportTime = new DateTime(2021, 2, 6),
                    DBManualPath = "/Path/DB/File1.db",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Name = "Application A",
                    OpsManualPath = "/Path/Ops/Manual1.txt",
                    UserManualPath = "/Path/User/Manual1.txt",
                    Version = "1.0.2",
                    AppLicenseType = _appLicenseTypeRepository.GetAppLicenseTypes().ToList()[0],
                    AppType = _appTypeRepository.GetAppTypes().ToList()[0],
                    Manufacturer = _companyRepository.GetManufacturers().ToList()[0],
                    Supplier = _companyRepository.GetSuppliers().Where(c => c.isSupplier).ToList()[0],
                    HighAvailable = true,
                    NeedADAuthentication = false,
                    Support = false,
                    IsActive = true,
                    UseProcesses = false
                },

                new Application
                {
                    Id = new Guid("9379183f-0293-4f2c-ba93-b2869562c22b"),
                    Abbreviation = "BB",
                    AppSupportTime = new DateTime(2021, 2, 6),
                    DBManualPath = "/Path/DB/File2.db",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                    Name = "Application B",
                    OpsManualPath = "/Path/Ops/Manual2.txt",
                    UserManualPath = "/Path/User/Manual2.txt",
                    Version = "1.0.2",
                    AppLicenseType = _appLicenseTypeRepository.GetAppLicenseTypes().ToList()[1],
                    AppType = _appTypeRepository.GetAppTypes().ToList()[1],
                    Manufacturer = _companyRepository.GetManufacturers().ToList()[1],
                    Supplier = _companyRepository.GetSuppliers().ToList()[1],

                },
            };

        public Application GetApplicationById(Guid applicationId)
        {
            return GetApplications.FirstOrDefault(a => a.Id == applicationId);
        }

        public ICollection<Application> GetApplicationsByNameAndSupplierNameAndAppType(string ApplicationName, string SupplierName, Guid AppTypeId)
        {
            throw new NotImplementedException();
        }

        public string GetFileName(string path)
        {
            String[] pathSplit = path.Split('/');
            String fileName = pathSplit[pathSplit.Length - 1];
            return fileName;
        }

        public bool Exists(Guid applicationId)
        {
            return GetApplications.Any(a => a.Id == applicationId);
        }

        public void Save(Application application)
        {

            GetApplications.Add(application);
        }

        public void Delete(Guid applicationId)
        {
            var application = GetApplicationById(applicationId);
            GetApplications.Remove(application);
        }
    }
}