using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmsSolutions.Entities
{
    public class Venda
    {
        public int VendaId { get; set; }
        public string NomeProd { get; set; }
        public int QdeProduto { get; set; } 
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double Valor { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataVenda { get; set; }
        public string FormaPg { get ; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PgaReceber { get; set; }
        public int ClienteId { get; set; }
       // public string Clientes { get ; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<RlClientVenda> RlClientVendas { get; set; }

    }
}
