using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public class AppLicenseTypeRepository : IAppLicenseTypeRepository
    {
        private AppDbContext _appDbContext = new AppDbContext();

        public List<SelectListItem> GetAppLicenseTypesDropdown(Guid id = default(Guid))
        {
            var guidIsEmpty = id == Guid.Empty;
            var items = this.GetAppLicenseTypes().Select(m =>
                                    new SelectListItem()
                                    {
                                        Text = m.Description,
                                        Value = m.Id.ToString(), 
                                    }).ToList();
            items.Insert(0,
                new SelectListItem()
                {
                    Text = "--- Select App License Type ---",
                    Value = Guid.Empty.ToString()
                });
            var selected = items.First(i => Guid.Parse(i.Value).Equals(guidIsEmpty ? Guid.Empty : id));
            selected.Selected = true;
            return items;
        }

        public IEnumerable<AppLicenseType> GetAppLicenseTypes()
        {
            return _appDbContext.AppLicenseTypes.ToList();
        }
    }
}