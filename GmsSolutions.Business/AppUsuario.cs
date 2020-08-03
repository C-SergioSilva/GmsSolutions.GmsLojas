using GmsSolutions.DBreposotorio;
using GmsSolutions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmsSolutions.Business
{
    public class AppUsuario
    {
        private readonly BdUsuario bdUsuario;
        public AppUsuario()
        {
            bdUsuario = new BdUsuario();
        }
        public void Insert(Usuario usuario)
        {
            bdUsuario.Insert(usuario);
        }
        public void Deletet(int id, Usuario usuario)
        {
            bdUsuario.Delete(id,usuario);
        }
        public Usuario List(int id)
        {
           return bdUsuario.List(id);
        }
        public IEnumerable<Usuario> Select()
        {
            return bdUsuario.CreateSelect();
        }
    }
}
