using ChangeManagementInventory.ViewModels;
using ChangeManagementInventory.ViewModels.Validators;
using System;
using System.DirectoryServices.AccountManagement;
using System.Web.Mvc;

namespace ChangeManagementInventory.Controllers
{
    // /Auth
    public class AuthController : Controller
    {

        public ActionResult Login()
        {
            return this.View();
        }

        // /Auth/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model, String ReturnUrl)
        {

            var validator = new LoginViewModelValidator();
            var result = validator.Validate(model);


            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(model);
            }

            var pc = new PrincipalContext(ContextType.Machine);
           
                var isValid = pc.ValidateCredentials(model.Username, model.Password);

                if (isValid)
                {
                if (this.Url.IsLocalUrl(ReturnUrl)
                    && ReturnUrl.Length > 1
                    && ReturnUrl.StartsWith("/")
                    && !ReturnUrl.StartsWith("//")
                    && !ReturnUrl.StartsWith("/\\")
                    )
                {
                    return this.Redirect(ReturnUrl);
                }
                return Redirect("/Applications/Index");

                }
            

            ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
            return View(model);
        }
    }
}