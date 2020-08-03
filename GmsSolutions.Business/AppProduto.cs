using GmsSolutions.DBreposotorio;
using GmsSolutions.Entities;
using System.Collections.Generic;

namespace GmsSolutions.Business
{
    public class AppProduto 

    {
        private readonly BdProduto bdProduto ;

        public AppProduto()
        {
            bdProduto = new BdProduto();
        }

        public void Inserir(Produto produto)
        {
            bdProduto.Inserir(produto);
        }
        public void Delete(int id, Produto produto)
        {
             bdProduto.Delete(id,produto);
        }
        public Produto Buscar(int id)
        {
            return bdProduto.Buscar(id);
        }
        public IEnumerable<Produto> Select()
        {
            return bdProduto.Select();
        }      
       
    }
}
