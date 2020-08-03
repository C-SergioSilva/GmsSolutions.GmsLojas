using GmsSolutions.Business;
using GmsSolutions.Entities;
using System.Net;
using System.Web.Mvc;

namespace GmsSolutions.UI.Controllers
{
    [Authorize(Users = "csergio@silva.com")]
    public class ProdutoController : Controller
    {     
        public AppProduto appProduto;
        public ProdutoController()
        {
            appProduto = new AppProduto();
        }
        public ActionResult Index( )
        {
           var listaProd = appProduto.Select();
            return View(listaProd);
        }      
        public ActionResult Detalhes(int id)
        {
            var listaProd = appProduto.Buscar(id);
            if (listaProd == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(listaProd);
        }   
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    appProduto.Inserir(produto);
                    return RedirectToAction("Index");
                }

                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }
        public ActionResult Delete(int id)
        {
            var produto = appProduto.Buscar(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        [HttpPost]
        public ActionResult Delete(int id, Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                produto = appProduto.Buscar(id);
                appProduto.Delete(id, produto);
                return RedirectToAction("Index");
                }
                return View(produto);
            }

            catch
            {
                return View(produto);
            }
        }
        public ActionResult Editar(int id)
        {
            var prod = appProduto.Buscar(id);
            if (prod == null)
            {
                return HttpNotFound();
            }
            return View(prod); 
        }
        [HttpPost]
        public ActionResult Editar(Produto produto)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    appProduto.Inserir(produto);
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View();
            }
        }
       
    }
}
