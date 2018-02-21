using Sistema_de_Controle_de_Alunos.Classes;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sistema_de_Controle_de_Alunos
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.ControleContext, Migrations.Configuration>());
            this.ChecarRoles();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ChecarRoles()
        {
            Utilidades.CheckRole("admin");
            Utilidades.CheckRole("professor");
            Utilidades.CheckRole("estudante");
        }
    }
}
