using GmsSolutions.DBreposotorio;
using GmsSolutions.Entities;
using System.Collections.Generic;


namespace GmsSolutions.Business
{
    public class AppCliente 
    {
        private readonly BdCliente bdCliente;
        public AppCliente()
        {
          bdCliente = new BdCliente();
        }
        public void Inserir(Cliente cliente)
        {
            bdCliente.Insert(cliente);
        }
        public void Delete(int id, Cliente cliente)
        {
            bdCliente.Delete(id, cliente);
        }
        public Cliente Buscar(int id)
        {
           return bdCliente.List(id);
        }
        public IEnumerable<Cliente> Select()
        {
            return bdCliente.Select();
        }

        public  IEnumerable<Cliente> CreateSelect()
        {
            return bdCliente.CreateSelect();
        }


       
    }
}
