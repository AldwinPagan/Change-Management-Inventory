using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public class CompanyRepository : ICompanyRepository
    {
        private AppDbContext _appDbContext = new AppDbContext();

        public IEnumerable<Company> GetManufacturers()
        {
            return _appDbContext.Companies.Where(c => c.isManufacturer);
        }

        public List<SelectListItem> GetManufacturersDropdown(Guid id = default(Guid))
        {
            var guidIsEmpty = id == Guid.Empty;
            var items = this.GetManufacturers().Select(m =>
                                    new SelectListItem ()
                                    {
                                        Text = m.Name,
                                        Value = m.Id.ToString()
                                    }).ToList();
            items.Insert(0,
                new SelectListItem()
                {
                    Text = "--- Select Manufacturer ---",
                    Value = Guid.Empty.ToString()
                });
            var selected = items.First(i => Guid.Parse(i.Value).Equals(guidIsEmpty ? Guid.Empty : id));
            selected.Selected = true;
            return items;
        }

        public IEnumerable<Company> GetSuppliers()
        {
            return _appDbContext.Companies.Where(c => c.isSupplier);
        }

        public List<SelectListItem> GetSuppliersDropdown(Guid id = default(Guid))
        {
            var guidIsEmpty = id == Guid.Empty;
            var items = this.GetSuppliers().Select(m =>
                                    new SelectListItem()
                                    {
                                        Text = m.Name,
                                        Value = m.Id.ToString()
                                    }).ToList();
            items.Insert(0,
                new SelectListItem()
                {
                    Text = "--- Select Supplier ---",
                    Value = Guid.Empty.ToString()
                });
            var selected = items.First(i => Guid.Parse(i.Value).Equals(guidIsEmpty? Guid.Empty : id));
            selected.Selected = true;
            return items;
        }
    }
}