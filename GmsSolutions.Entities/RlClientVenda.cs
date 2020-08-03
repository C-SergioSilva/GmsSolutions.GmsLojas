using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmsSolutions.Entities
{
    public class RlClientVenda
    {
        [Key]
        public int RelacaoCliVenId { get; set; }
        public int VendaId { get; set; }
        public int ClienteId { get; set; }


        public virtual Venda Venda { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
