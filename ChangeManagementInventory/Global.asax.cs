using Autofac;
using Autofac.Integration.Mvc;
using ChangeManagementInventory.Models;
using FluentValidation.Mvc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ChangeManagementInventory
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = BuildContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            FluentValidationModelValidatorProvider.Configure();

        }

        private IContainer BuildContainer()
        {
            // https://autofaccn.readthedocs.io/en/v4.9.4/integration/mvc.html#quick-start
            var builder = new ContainerBuilder();

            // Registering MVC Controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Registering Entity Framework DB Context
            builder.RegisterType<AppDbContext>()
                .AsImplementedInterfaces()
                .InstancePerMatchingLifetimeScope();


            // Registering Repositories
            //builder.RegisterType<ApplicationRepository>().As<IApplicationRepository>();
            //builder.RegisterType<AppLicenseTypeRepository>().As<IAppLicenseTypeRepository>();
            //builder.RegisterType<AppTypeRepository>().As<IAppTypeRepository>();
            //builder.RegisterType<CompanyRepository>().As<ICompanyRepository>();

            // Testing with MockRepositories
            //builder.RegisterType<MockApplicationRepository>().As<IApplicationRepository>();
            //builder.RegisterType<MockAppLicenseTypeRepository>().As<IAppLicenseTypeRepository>();
            //builder.RegisterType<MockAppTypeRepository>().As<IAppTypeRepository>();
            //builder.RegisterType<MockCompanyRepository>().As<ICompanyRepository>();

            return builder.Build();


        }
    }
}
