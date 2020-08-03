using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;
using GmsSolutions.Entities.Contrato;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GmsSolutions.DBreposotorio
{
    public class BdProduto 
    {
        private readonly LojaContext lojaContext;

        public BdProduto()
        {
            lojaContext = new LojaContext();
        }
        public void Inserir(Produto produto)
        {
            if (produto.Id > 0)
            {
                lojaContext.Entry(produto).State = EntityState.Modified;
            }
            else
            {
                lojaContext.Produtos.Add(produto);
            }
            lojaContext.SaveChanges();
        }
        public void Delete(int id, Produto produto)
        {
            produto = lojaContext.Produtos.Find(id);
            lojaContext.Set<Produto>().Remove(produto);
            lojaContext.SaveChanges();
        }
        public Produto Buscar(int id)
        {
            return lojaContext.Produtos.First(x => x.Id == id);
        }
        public IEnumerable<Produto> Select()
        {
            return lojaContext.Produtos;
        }

    }
}
