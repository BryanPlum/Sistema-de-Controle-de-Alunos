using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema_de_Controle_de_Alunos.Startup))]
namespace Sistema_de_Controle_de_Alunos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
