using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public class MockAppLicenseTypeRepository : IAppLicenseTypeRepository
    {
        public IEnumerable<AppLicenseType> appLicenseTypes =
        new List<AppLicenseType>
           {
               new AppLicenseType
               {
                   Id = Guid.Empty,
                   Description ="License Type 1"
               },
               new AppLicenseType
               {
                   Id = new Guid(),
                   Description ="License Type 2"
               }
           };

        public IEnumerable<AppLicenseType> GetAppLicenseTypes()
        {
            return this.appLicenseTypes;
        }

        public List<SelectListItem> GetAppLicenseTypesDropdown(Guid id = default(Guid))
        {
            var guidIsEmpty = id == Guid.Empty;
            var items = this.GetAppLicenseTypes().Select(m =>
                                    new SelectListItem()
                                    {
                                        Text = m.Description,
                                        Value = m.Id.ToString()
                                    }).ToList();
            items.Add(
                new SelectListItem()
                {
                    Text = "--- Select App Licens Type ---",
                    Value = Guid.Empty.ToString()
                });
            var selected = items.First(i => Guid.Parse(i.Value).Equals(guidIsEmpty ? Guid.Empty : id));
            selected.Selected = true;
            return items;

        }
    }
}