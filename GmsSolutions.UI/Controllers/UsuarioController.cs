using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GmsSolutions.Business;
using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;

namespace GmsSolutions.UI.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly AppUsuario appUsuario;
        public UsuarioController()
        {
            appUsuario = new AppUsuario();
        }
        public ActionResult Index()
        {
            var user = appUsuario.Select();
            return View(user);
        }
        public ActionResult Detalhes(int id)
        {
            var user = appUsuario.List(id);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            return View(user);
        }
        public ActionResult Cadastrar()
        {
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                appUsuario.Insert(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        public ActionResult Editar(int id)
        {
            var user = appUsuario.List(id);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            return View(user);
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appUsuario.Insert(user);
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch
            { 
                return View(user);
            }
            
        }
        public ActionResult Delete(int id)
        {
            var user = appUsuario.List(id);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user = appUsuario.List(id);
                    appUsuario.Deletet(id,user);
                    return RedirectToAction("Index");

                }
                return View(user);
            }
            catch
            {

                return View(user);
            }
           
        }

    }
}
