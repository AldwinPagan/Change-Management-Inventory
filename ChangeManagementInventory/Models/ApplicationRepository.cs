using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;

namespace ChangeManagementInventory.Models
{
    public class ApplicationRepository : IApplicationRepository
    {
        private AppDbContext _appDbContext = new AppDbContext();

        public ApplicationRepository()
        {
            _appDbContext = new AppDbContext();
        }
        public ICollection<Application> GetApplications
        {
            get
            {
                return _appDbContext.Applications
                    .Include("Supplier")
                    .Include("AppLicenseType")
                    .Include("AppType")
                    .Include("Manufacturer")
                    .ToList();
            }
        }

        public Application GetApplicationById(Guid applicationId)
        {
            return _appDbContext.Applications
                    .Include("Supplier")
                    .Include("AppLicenseType")
                    .Include("AppType")
                    .Include("Manufacturer")
                    .FirstOrDefault(a => a.Id.Equals(applicationId));
        }


        public ICollection<Application> GetApplicationsByNameAndSupplierNameAndAppType(String ApplicationName, String SupplierName, Guid AppTypeId)
        {

            if(String.IsNullOrEmpty(ApplicationName) && String.IsNullOrEmpty(SupplierName) && AppTypeId.Equals(Guid.Empty))
            {
                return GetApplications;
            }
            var query = _appDbContext.Applications
                .Include("Supplier")
                .Include("AppLicenseType")
                .Include("AppType")
                .Include("Manufacturer").AsQueryable();

            if (!String.IsNullOrEmpty(ApplicationName))
            {
                query = query.Where(x => x.Name.ToLower().Contains(ApplicationName.ToLower()));
            }

            if (!String.IsNullOrEmpty(SupplierName))
            {
                query = query.Where(x => x.Supplier.Name.ToLower().Contains(SupplierName.ToLower()));
            }

           if(!AppTypeId.Equals(Guid.Empty))
            {
                query = query.Where(x => x.AppTypeId == AppTypeId);
            }

            return query.ToList();
        }

        public string GetFileName(string path)
        {
            String[] pathSplit = path.Split('\\');
            String fileName = pathSplit[pathSplit.Length - 1];
            return fileName;
        }

        public void Save(Application application)
        {
            _appDbContext.Applications.AddOrUpdate(application);
            _appDbContext.SaveChanges();
        }

        public bool Exists(Guid applicationId)
        {
            return _appDbContext.Applications.Any(a => a.Id == applicationId);
        }

        public void Delete(Guid applicationId)
        {
            var application = new Application() { Id = applicationId };
            _appDbContext.Applications.Attach(application);
            _appDbContext.Applications.Remove(application);
            _appDbContext.SaveChanges();
        }
    }
}
