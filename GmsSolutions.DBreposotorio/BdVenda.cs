using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;
using GmsSolutions.Entities.Contrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmsSolutions.DBreposotorio
{
    public class BdVenda 
    {
        private readonly LojaContext lojaContext;
        public BdVenda()
        {
            lojaContext = new LojaContext();

        }
        public void Insert(Venda venda)
        {
          if(venda.VendaId > 0 )
          {
                lojaContext.Entry(venda).State = EntityState.Modified;
            }
            else
            {
                
                lojaContext.Vendas.Add(venda);
            }

           try
            {
                if(venda.ClienteId > 0)
                {
                    lojaContext.SaveChanges();
                }

            }
            catch (Exception)
            {

                
            }
            

        }
        public void Delete(int id, Venda venda)
        {
            venda = lojaContext.Vendas.Find(id);
            lojaContext.Set<Venda>().Remove(venda);
            lojaContext.SaveChanges();

        }
        public Venda List(int id)
        {
            return  lojaContext.Vendas.First(x => x.VendaId == id);

        }
        public IEnumerable<Venda> Select() 
        {
            return lojaContext.Vendas;
        }
       public IEnumerable<RlClientVenda> SelectList() 
        {
            return lojaContext.RelacaoClientVendas;
        }
    }
}
