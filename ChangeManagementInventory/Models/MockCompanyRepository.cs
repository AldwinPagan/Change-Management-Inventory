using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ChangeManagementInventory.Models
{
    public class MockCompanyRepository : ICompanyRepository
    {
        private List<Company> companies = new List<Company>
         {
             new Company
             {
                 Id = Guid.Empty,
                 Address = "Address 1",
                 BusinessPhone = "1 (800) 234-4567",
                 FaxPhone = "1 (800) 432-4567",
                 isManufacturer = true,
                 isSupplier = false,
                 Name = "Vendor A",

             },
            new Company
             {
                 Id = new Guid(),
                 Address = "Address 2",
                 BusinessPhone = "1 (800) 234-4567",
                 FaxPhone = "1 (800) 432-4567",
                 isManufacturer = false,
                 isSupplier = true,
                 Name = "Vendor B",

             },
             new Company
             {
                 Id = new Guid(),
                 Address = "Address 3",
                 BusinessPhone = "1 (800) 234-4567",
                 FaxPhone = "1 (800) 432-4567",
                 isManufacturer = true,
                 isSupplier = false,
                 Name = "Vendor C",

             },
            new Company
             {
                 Id = new Guid(),
                 Address = "Address 4",
                 BusinessPhone = "1 (800) 234-4567",
                 FaxPhone = "1 (800) 432-4567",
                 isManufacturer = false,
                 isSupplier = true,
                 Name = "Vendor D",

             },
         };
            
        
        
        public Company GetCompanyById(Guid companyId)
        {
           return this.companies.FirstOrDefault(c => c.Id.Equals(companyId));
        }

        public IEnumerable<Company> GetManufacturers()
        {
            return this.companies.Where(c => c.isManufacturer);
        }

        public List<SelectListItem> GetManufacturersDropdown(Guid id = default(Guid))
        {
            var items = this.GetManufacturers().Select(m =>
                         new SelectListItem()
                         {
                             Text = m.Name,
                             Value = m.Id.ToString()
                         }).ToList();
            items.Add(
                new SelectListItem()
                {
                    Text = "--- Select Manufacturer ---",
                    Value = Guid.Empty.ToString()
                });
            var selected = items.Where(i => Guid.Parse(i.Value).Equals(id)).First();
            selected.Selected = true;
            return items;
        }

        public IEnumerable<Company> GetSuppliers()
        {
            return this.companies.Where(c => c.isSupplier);
        }

        public List<SelectListItem> GetSuppliersDropdown(Guid id = default(Guid))
        {
            var items = this.GetManufacturers().Select(m =>
                        new SelectListItem()
                        {
                            Text = m.Name,
                            Value = m.Id.ToString()
                        }).ToList();
            items.Add(
                new SelectListItem()
                {
                    Text = "--- Select Supplier ---",
                    Value = Guid.Empty.ToString()
                });
            var selected = items.Where(i => Guid.Parse(i.Value).Equals(id)).First();
            selected.Selected = true;
            return items;
        }
    }
}