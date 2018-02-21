using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

/* Esta será a classe principal de comunicação com o banco de dados, e devemos dizer isso ao sistema, através do Nuget. Abrindo o console 
 * do nuget, digitamos Enable-Migrations -ContextTypeName ControleContext -EnableAutomaticMigrations -Force*/

namespace Sistema_de_Controle_de_Alunos.Models
{
    public class ControleContext : DbContext
    {
        public ControleContext() : base("DefaultConnection")
        {

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}