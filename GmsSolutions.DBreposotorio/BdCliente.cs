using GmsSolutions.DBreposotorio.Context;
using GmsSolutions.Entities;
using GmsSolutions.Entities.Contrato;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GmsSolutions.DBreposotorio
{
    public  class BdCliente 
    {
        public readonly LojaContext lojaContext;
        
        public BdCliente()
        {
            lojaContext = new LojaContext();
        }

        public void Insert(Cliente cliente)
        {
            if (cliente.ClienteId > 0)
            {
                lojaContext.Entry(cliente).State = EntityState.Modified;
            }
            else
            {
                lojaContext.Clientes.Add(cliente);
            }
            try
            {
               
                lojaContext.SaveChanges();
            }
            catch (Exception)
            {

              
            }
            
        }

        public void Delete(int id, Cliente cliente)
        {
            cliente = lojaContext.Clientes.Find(id);
            lojaContext.Set<Cliente>().Remove(cliente);
            try
            {
                lojaContext.SaveChanges();
            }
            catch 
            {
               
              
            }
            
        }

        public Cliente List(int id)
        {
            return lojaContext.Clientes.First(x => x.ClienteId == id);
        }

        public IEnumerable<Cliente> Select() 
        {
            return lojaContext.Clientes;
        }

        public IEnumerable<Cliente> CreateSelect()
        {
            var list = lojaContext.Clientes.ToList();
            list.Add(new Cliente { ClienteId = 0, Nome = " [ ESCOLHA UM CLIENTE ! ] " });
            list = list.OrderBy(x => x.Nome).ToList();  
            return list;
        }
       
    }
}
