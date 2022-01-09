using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public class AppTypeRepository : IAppTypeRepository
    {
        private AppDbContext _appDbContext = new AppDbContext();

        public List<SelectListItem> GetAppTypesDropdown(Guid id = default(Guid))
        {
            var guidIsEmpty = id == Guid.Empty;
            var items = this.GetAppTypes().Select(x =>
                                        new SelectListItem()
                                        {
                                            Text = x.Description,
                                            Value = x.Id.ToString()
                                        }).ToList();
            items.Insert(0, new SelectListItem() { Text = "--- Select App Type ---", Value = Guid.Empty.ToString() });
            var selected = items.First(i => Guid.Parse(i.Value).Equals(guidIsEmpty ? Guid.Empty : id));
            selected.Selected = true;
            return items;
        }


        public IEnumerable<AppType> GetAppTypes()
        {
            return _appDbContext.AppTypes.ToList();
        }
    }
}