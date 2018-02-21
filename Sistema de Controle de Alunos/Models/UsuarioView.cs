using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_de_Controle_de_Alunos.Models
{
    public class UsuarioView
    {
        public Usuario  Usuario { get; set; }

        public HttpPostedFileBase Foto { get; set; }
    }
}