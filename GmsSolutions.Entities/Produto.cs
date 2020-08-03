using System;
using System.ComponentModel.DataAnnotations;

namespace GmsSolutions.Entities
{
    public class Produto 
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Valor { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime UltimaCompra { get; set; }
        public float Estoque { get; set; }
        public string Fornecedor { get; set; }
        
    } 
}
