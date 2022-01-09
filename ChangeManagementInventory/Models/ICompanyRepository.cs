using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetSuppliers();
        IEnumerable<Company> GetManufacturers();
        List<SelectListItem> GetSuppliersDropdown(Guid id);
        List<SelectListItem> GetManufacturersDropdown(Guid id);
        

    }
}