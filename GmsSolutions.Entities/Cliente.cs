using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmsSolutions.Entities
{
    public class Cliente 
    {
        public int ClienteId { get; set; }
        public string Nome{ get; set; }
        public string Contato { get; set; }
        public string SobreNome { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }

        public virtual ICollection<RlClientVenda> RlClientVendas { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }

    }
}
