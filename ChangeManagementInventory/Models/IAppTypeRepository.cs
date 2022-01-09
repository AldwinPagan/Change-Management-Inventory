using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public interface IAppTypeRepository
    {
        IEnumerable<AppType> GetAppTypes();
        List<SelectListItem> GetAppTypesDropdown(Guid id);
    }
}
