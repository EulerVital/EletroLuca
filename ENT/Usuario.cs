using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENT
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "* E-mail obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Senha obrigatória")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "O campo deve ter mais ou igual a {1} e menos ou igual a {0}", MinimumLength = 6)]
        public string Senha { get; set; }

        public virtual Perfil Perfil { get; set; }

        [Required(ErrorMessage = "Selecione um perfil")]
        public int PerfilId { get; set; }
    }
}
