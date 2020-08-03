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
    public class ClienteController : Controller
    {
        public AppCliente appCliente;
        public ClienteController()
        {
            appCliente = new AppCliente();
        }
        public ActionResult Index()
        {
            var listCliente = appCliente.Select();
            return View(listCliente);
            
        }
        public ActionResult Detalhes(int id)
        {
            var listCliente = appCliente.Buscar(id);
            if (listCliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(listCliente);
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appCliente.Inserir(cliente);
                    return RedirectToAction("Index");
                }

                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }
        public ActionResult Editar(int id)
        {
            var cliente = appCliente.Buscar(id);
            if (cliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appCliente.Inserir(cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            var cliente = appCliente.Buscar(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cliente = appCliente.Buscar(id);
                    appCliente.Delete(id, cliente);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);

            }
        }
    }
}
