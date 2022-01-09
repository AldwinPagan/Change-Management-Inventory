using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChangeManagementInventory.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool isSupplier { get; set; }
        public bool isManufacturer { get; set; }
        public string BusinessPhone { get; set; }
        public string FaxPhone { get; set; }
        public string Address { get; set; }
        public string stringCity { get; set; }
        public string stringStateProvince { get; set; }
        public string stringZipCode { get; set; }
        public string stringCountryRegion { get; set; }
        public string stringWebPage { get; set; }
        public string stringNotes { get; set; }

    }
}