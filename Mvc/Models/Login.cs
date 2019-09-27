using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Preencha o campo e-mail para logar")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha o campo senha para se logar")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public int PerfilId { get; set; }

    }
}
