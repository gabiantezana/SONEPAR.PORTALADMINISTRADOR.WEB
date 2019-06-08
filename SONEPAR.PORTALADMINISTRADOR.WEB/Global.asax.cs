using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ExpressiveAnnotations.Attributes;
using Hangfire;
using Hangfire.SqlServer;
using SONEPAR.PORTALADMINISTRADOR.WEB.MODEL;
using ExpressiveAnnotations.MvcUnobtrusive.Providers;
using ExpressiveAnnotations.MvcUnobtrusive.Validators;
namespace SONEPAR.PORTALADMINISTRADOR.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private BackgroundJobServer _backgroundJobServer;

        protected void Application_Start()
        {
            try
            {

                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

                //--------------------------------------------------SINCRONIZACIÓN--------------------------------------------------
                //GlobalConfiguration.Configuration.UseSqlServerStorage(new SICEREntities().Database.Connection.ConnectionString);
                //_backgroundJobServer = new BackgroundJobServer();


                //BackgroundJob.Enqueue(() => DoWork());

                //--------------------------------------------------SINCRONIZACIÓN--------------------------------------------------

                //REQUIREDIF
                DataAnnotationsModelValidatorProvider.RegisterAdapter(
                    typeof(RequiredIfAttribute), typeof(RequiredIfValidator));
                DataAnnotationsModelValidatorProvider.RegisterAdapter(
                    typeof(AssertThatAttribute), typeof(AssertThatValidator));

                ModelValidatorProviders.Providers.Remove(
                    ModelValidatorProviders.Providers
                        .FirstOrDefault(x => x is DataAnnotationsModelValidatorProvider));
                ModelValidatorProviders.Providers.Add(
                    new ExpressiveAnnotationsModelValidatorProvider());
                //
            }
            catch (Exception ex)
            {

            }


        }
    }
}

