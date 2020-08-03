using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmsSolutions.Entities
{
    public class CategoriaPg
    {
        public int Id { get; set; }

        [Display(Name= "Descrição")]
        [Required(ErrorMessage = "Insira um tipo de pgamento")]
        public string Descricao { get; set; }

    }
}
