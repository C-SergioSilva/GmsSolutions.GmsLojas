using System;
using System.ComponentModel.DataAnnotations;

namespace GmsSolutions.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DescProduto { get; set; } 
        public int QdeCompra { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public double ValorCompra { get; set; } 
        public string Contato { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataCompra { get; set; } 
    }
}

