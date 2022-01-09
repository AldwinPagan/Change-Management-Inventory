using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeManagementInventory.Models
{
    public interface IApplicationRepository
    {
        ICollection<Application> GetApplications { get; }
        Application GetApplicationById(Guid applicationId);
        ICollection<Application> GetApplicationsByNameAndSupplierNameAndAppType(String ApplicationName, String SupplierName, Guid AppTypeId);
        String GetFileName(String path);
        bool Exists(Guid applicationId);
        void Save(Application application);
        void Delete(Guid applicationId);
    }
}
