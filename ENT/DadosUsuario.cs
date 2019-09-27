using System;
using System.Collections.Generic;
using System.Text;

namespace ENT
{
    public class DadosUsuario
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}
