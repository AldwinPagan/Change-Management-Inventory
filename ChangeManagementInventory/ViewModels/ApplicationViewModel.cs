using ChangeManagementInventory.Models;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChangeManagementInventory.ViewModels
{
    public class ApplicationViewModel
    {
        public Application Application { get; set; }
        public List<SelectListItem> AppTypes { get; set; }
        public List<SelectListItem> Suppliers { get; set; }
        public List<SelectListItem> Manufacturers { get; set; }
        public List<SelectListItem> AppLicenseTypes { get; set; }

        public String Name { get; set; }
        public String Abbreviation { get; set; }
        public String Description { get; set; }
        public String Version { get; set; }
        public String SelectedManufacturerId { get; set; }
        public String SelectedSupplierId { get; set; }
        public bool? Support { get; set; }
        public String UserManualFileName { get; set; }
        public String OpsManualFileName { get; set; }
        public String DBManualFileName { get; set; }
        public bool? HighAvailable { get; set; }
        public bool? IsActive { get; set; }
        public bool? UseProcesses { get; set; }
        public bool? NeedADAuthentication { get; set; }
        public String SelectedAppTypeId { get; set; }
        public String SelectedAppLicenseTypeId { get; set; }
        public DateTime AppSupportTime { get; set; }
        public String Id { get; set; }
    }
}