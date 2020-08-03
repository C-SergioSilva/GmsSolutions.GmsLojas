using System.ComponentModel.DataAnnotations;

namespace GmsSolutions.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }

    }
}
