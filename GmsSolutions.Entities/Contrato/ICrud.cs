using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmsSolutions.Entities.Contrato
{
    public interface ICrud<IC> where IC : class
    {
        void Insert(IC Entidade);
        IC List(int id);
        IEnumerable<IC> CreateSelect();
    }
}
