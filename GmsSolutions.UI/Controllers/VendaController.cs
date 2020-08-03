using GmsSolutions.Business;
using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace GmsSolutions.UI.Controllers
{
    public class VendaController : Controller
    {
        private LojaContext db = new LojaContext(); 
        private readonly AppCliente appCliente; 
        private readonly AppVenda appVenda;
        public VendaController()
        {
            appCliente = new AppCliente();
            appVenda   = new AppVenda  ();
        }

        public ActionResult Index()
        {
             var vd = db.Vendas.Include(c => c.Cliente);
             return View(vd.ToList());
             
        }

        public ActionResult Detalhes(int id)
         {
             var venda = appVenda.List(id);
             if (venda == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }

             return View(venda);
         }
         public ActionResult Cadastrar()
         {

             ViewBag.ClienteId = new SelectList(appCliente.CreateSelect(), "ClienteId", "Nome");
             return View();
         } 
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Cadastrar([Bind(Include = "VendaId,NomeCli,NomeProd,QdeProduto,Valor,DataVenda,FormaPg,PgaReceber,ClienteId,Nome")] Venda venda)
         {

             if (ModelState.IsValid)
             {
                 appVenda.Inserir(venda);
                 return RedirectToAction("Index");
             }  
             return View(venda);
         }
         public ActionResult Editar(int id)
         {
             var venda = appVenda.List(id);
             if (venda == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }

             ViewBag.ClienteId = new SelectList(appCliente.Select(), "ClienteId", "Nome", venda.ClienteId);
             return View(venda);
         }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public ActionResult Editar([Bind(Include = "VendaId,NomeCli,NomeProd,QdeProduto,Valor,DataVenda,FormaPg,PgaReceber, Nome,ClienteId")] Venda venda)
         {
             if (ModelState.IsValid)
             {
                 appVenda.Inserir(venda);
                 return RedirectToAction("Index");
             }
             ViewBag.ClienteId = new SelectList(appCliente.Select(), "ClienteId", "Nome", venda.ClienteId);
             return View(venda);
         }
         public ActionResult Delete(int id)
         {
             var venda = appVenda.List(id);
             if (venda == null)
             {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             } 
             return View(venda);
         }
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public ActionResult DeleteConfirmed(int id, Venda venda)
         {
             try
             {
                 if (ModelState.IsValid)
                 {
                     venda = appVenda.List(id);
                     appVenda.Delete(id, venda);
                     return RedirectToAction("Index");
                 }
                 return View(venda);
             }
             catch
             {
                 return View(venda);
             }          
         }      
     }
 }
