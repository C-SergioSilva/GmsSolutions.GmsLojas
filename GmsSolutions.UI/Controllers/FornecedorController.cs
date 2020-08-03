using GmsSolutions.Business;
using GmsSolutions.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GmsSolutions.UI.Controllers
{
    public class FornecedorController : Controller
    {
        public AppFornecedor appFornecedor;
        public FornecedorController()
        {
            appFornecedor = new AppFornecedor();
        }
        public ActionResult Index()
        {
            var listFor = appFornecedor.Select();
            return View(listFor);
        }
        public ActionResult Detalhes(int id)
        {
            var cliente = appFornecedor.List(id);
            if (cliente == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(cliente);
        } 
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appFornecedor.Insert(fornecedor);
                    return RedirectToAction("Index");
                }
                return View(fornecedor);
            }
            catch 
            {
                return View(fornecedor);
            }
           
           
        }
        public ActionResult Editar(int id)
        {
            var listFor = appFornecedor.List(id);
            if (listFor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(listFor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                appFornecedor.Insert(fornecedor);
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }
        public ActionResult Delete(int id)
        {
            var listFor = appFornecedor.List(id);
            if (listFor == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(listFor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var listFor = appFornecedor.List(id);
                    appFornecedor.Delete(id, listFor);
                    return RedirectToAction("Index");
                    
                }
                return View(fornecedor);
            }


            catch
            {

                return View(fornecedor);
            }

        }
    }
}
            
            
