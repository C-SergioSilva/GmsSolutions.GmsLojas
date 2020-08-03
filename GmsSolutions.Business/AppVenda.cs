using GmsSolutions.DBreposotorio;
using GmsSolutions.Entities;
using System.Collections.Generic;

namespace GmsSolutions.Business
{
    public class AppVenda
     {
        private readonly BdVenda bdVenda;
       
        public AppVenda()
        {
           bdVenda = new BdVenda();
            
        }
        public void Inserir(Venda venda)
        {
            bdVenda.Insert(venda);
        }
        public void Delete(int id, Venda venda)
        {
            bdVenda.Delete(id, venda);
        }
        public Venda List(int id)
        {
            return bdVenda.List(id);
        }
        public IEnumerable<Venda> Select()
        {
            return bdVenda.Select(); 
        }
        public IEnumerable<RlClientVenda> SelectList()
        {
            return bdVenda.SelectList(); 
        }
    }
}
