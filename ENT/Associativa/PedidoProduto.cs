using System;
using System.Collections.Generic;
using System.Text;

namespace ENT.Associativa
{
    public class PedidoProduto
    {
        public int Id { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }

    }
}
