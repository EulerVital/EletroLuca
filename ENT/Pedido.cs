using System;
using System.Collections.Generic;
using System.Text;

namespace ENT
{
    public class Pedido
    {
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual List<Produto> Produtos { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Data { get; set; }
    }
}
