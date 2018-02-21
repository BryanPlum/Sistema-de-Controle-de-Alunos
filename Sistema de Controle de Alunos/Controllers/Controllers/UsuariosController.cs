using Sistema_de_Controle_de_Alunos.Classes;
using Sistema_de_Controle_de_Alunos.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Sistema_de_Controle_de_Alunos.Controllers
{
    public class UsuariosController : Controller
    {
        private ControleContext db = new ControleContext();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(db.Usuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioView view)
        ///([Bind(Include = "UserId,UserName,Nome,Sobrenome,Telefone,Endereco,Photo,Estudante,Professor")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(view.Usuario);
                try
                {

                    if (view.Foto != null)
                    {
                        var pic = Utilidades.UploadPhoto(view.Foto);
                        if (!string.IsNullOrEmpty(pic))
                        {
                            view.Usuario.Photo = string.Format("~/Content/Fotos/{0}", pic);
                        }
                    }
                    db.SaveChanges();

                    Utilidades.CreateUserASP(view.Usuario.UserName);//captura o email do novo usuário
                    if (view.Usuario.Estudante)
                    {
                        Utilidades.AddRoleToUser(view.Usuario.UserName, "estudante");
                    }
                    if (view.Usuario.Professor)
                    {
                        Utilidades.AddRoleToUser(view.Usuario.UserName, "professor");
                    }
                    //verifica-se se o email cadastrado for estudante, ou professor, e atribui as permissões

                    return RedirectToAction("Index");

                    Utilidades.CreateUserASP(view.Usuario.UserName);//UserName é o nome do campo e-mail nas tabelas do banco
                    if (view.Usuario.Estudante)
                    {
                        Utilidades.AddRoleToUser(view.Usuario.UserName, "Estudante");
                    }

                    if (view.Usuario.Professor)
                    {
                        Utilidades.AddRoleToUser(view.Usuario.UserName, "Professor");
                    }

                }
                catch (System.Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }

            return View(view);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            var view = new UsuarioView
            {
                Usuario = usuario
            };

            return View(view);
    }

    // POST: Usuarios/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UsuarioView view)
    {
        if (ModelState.IsValid)

                if (view.Foto != null)
                {
                    var pic = Utilidades.UploadPhoto(view.Foto);
                    if (!string.IsNullOrEmpty(pic))
                    {
                        view.Usuario.Photo = string.Format("~/Content/Fotos/{0}", pic);
                    }
                }
            {
            db.Entry(view.Usuario).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            return RedirectToAction("Index");
        }
        return View(view.Usuario);
    }

    // GET: Usuarios/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Usuario usuario = db.Usuarios.Find(id);
        if (usuario == null)
        {
            return HttpNotFound();
        }
        return View(usuario);
    }

    // POST: Usuarios/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        Usuario usuario = db.Usuarios.Find(id);
        db.Usuarios.Remove(usuario);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
}
