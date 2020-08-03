using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;
using GmsSolutions.Entities.Contrato;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GmsSolutions.DBreposotorio
{
    public class BdFornecedor : ICrud<Fornecedor>
    {
        private readonly LojaContext lojaContext;
        public BdFornecedor()
        {
            lojaContext = new LojaContext();
        }
        public void Insert(Fornecedor fornecedor)
        {
            if(fornecedor.Id > 0)
            {
                lojaContext.Entry(fornecedor).State = EntityState.Modified;   
            }
            else
            {
                lojaContext.Fornecedores.Add(fornecedor);
            }
            lojaContext.SaveChanges();
        }
        public void Delete(int id, Fornecedor fornecedor)
        {
            fornecedor = lojaContext.Fornecedores.Find(id);
            lojaContext.Set<Fornecedor>().Remove(fornecedor);
            lojaContext.SaveChanges();
        }
        public Fornecedor List(int id)
        {
            return lojaContext.Fornecedores.First(x => x.Id == id);
        }
        public IEnumerable<Fornecedor> CreateSelect()
        {
            return lojaContext.Fornecedores;
        }

    }
}
