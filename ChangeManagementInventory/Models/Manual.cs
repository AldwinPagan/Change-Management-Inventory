using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace ChangeManagementInventory.Models
{
    public class Manual
    {
        private const string MANUALS_FOLDER_PATH = "~/Content/Manuals";
        public String FilePath => _path;
        private HttpPostedFileBase _httpPostedFileBase;
        private readonly String _path;
        private String _fileName;
        private ManualType _type;
        private Manual(ManualType type, HttpPostedFileBase httpPostedFileBase): base()
        {
            
            _type = type;
            _httpPostedFileBase = httpPostedFileBase;
            _fileName = Path.GetFileName(httpPostedFileBase.FileName);
            _path = Path.Combine(
                HostingEnvironment.MapPath(
                    MANUALS_FOLDER_PATH
                    + Path.DirectorySeparatorChar
                    + _type.ToString()), 
                 _fileName);
        }

        public static Manual Create(ManualType type, HttpPostedFileBase httpPostedFileBase)
        {
            return new Manual(type, httpPostedFileBase);
        }

        public void Save()
        {
            _httpPostedFileBase.SaveAs(_path);
        }
    }

    public enum ManualType
    {
        Database,
        Operation,
        User
    }
}