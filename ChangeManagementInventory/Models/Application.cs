using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementInventory.Models
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        public Guid ManufacturerId { get; set; }
        public Company Manufacturer { get; set; }
        public Guid SupplierId { get; set; }
        public Company Supplier { get; set; }
        public bool? Support { get; set; }
        public string UserManualPath { get; set; }
        public string OpsManualPath { get; set; }
        public string DBManualPath { get; set; }
        public bool? HighAvailable { get; set; }
        public bool? IsActive { get; set; }
        public bool? UseProcesses { get; set; }
        public bool? NeedADAuthentication { get; set; }
        public Guid AppTypeId { get; set; }
        public AppType AppType { get; set; }
        public Guid AppLicenseTypeId { get; set; }
        public AppLicenseType AppLicenseType { get; set; }
        public DateTime AppSupportTime { get; set; }




    }
}