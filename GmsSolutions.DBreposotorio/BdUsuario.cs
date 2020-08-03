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
    public class BdUsuario : ICrud<Usuario>
    {
        private readonly LojaContext lojaContext;
        public BdUsuario()
        {
           lojaContext = new LojaContext();
        }
        public void Insert(Usuario usuario)
        {
            if(usuario.Id > 0)
            {
                lojaContext.Entry(usuario).State = EntityState.Modified;
            }
            else
            {
                lojaContext.Usuarios.Add(usuario);
            }
            lojaContext.SaveChanges();
        }
        public void Delete(int id, Usuario usuario)
        {
            usuario = lojaContext.Usuarios.Find(id);
            lojaContext.Set<Usuario>().Remove(usuario);
            lojaContext.SaveChanges();
        }
        public Usuario List(int id)
        {
            return lojaContext.Usuarios.First(x => x.Id == id);

        }
        public IEnumerable<Usuario> CreateSelect()
        {
            return lojaContext.Usuarios;
        }
    }
}
