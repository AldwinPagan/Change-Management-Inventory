using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public interface IAppLicenseTypeRepository
    {
        IEnumerable<AppLicenseType> GetAppLicenseTypes();
        List<SelectListItem> GetAppLicenseTypesDropdown(Guid id);
    }
}
