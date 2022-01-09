using ChangeManagementInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.ViewModels
{
    public class ApplicationsViewModel
    {
        public PagedList.IPagedList<Application> Applications { get; set; }
        public List<SelectListItem> AppTypes { get; set; }
        public String SelectedAppTypeId { get; set; }
        public String ApplicationName { get; set; }
        public String SupplierName { get; set; }

    }
}