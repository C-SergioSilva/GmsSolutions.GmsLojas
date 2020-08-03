using GmsSolutions.DBreposotorio;
using GmsSolutions.Entities;
using System.Collections.Generic;

namespace GmsSolutions.Business
{
    public class AppFornecedor
    {
        public readonly BdFornecedor bdFornecedor;
        public AppFornecedor()
        {
            bdFornecedor = new BdFornecedor();
        }
        public void Insert(Fornecedor fornecedor)
        {
            bdFornecedor.Insert(fornecedor);

        }
        public void Delete(int id,Fornecedor fornecedor)
        {
            bdFornecedor.Delete(id, fornecedor);

        }
        public Fornecedor List(int id)
        {
            return bdFornecedor.List(id);

        }
        public IEnumerable<Fornecedor> Select()
        {
            return bdFornecedor.CreateSelect();
        }

    }
}
