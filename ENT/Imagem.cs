using System;
using System.Collections.Generic;
using System.Text;

namespace ENT
{
    public class Imagem
    {
        public int Id { get; set; }
        public string CaminhoVirtual { get; set; }
        public virtual Produto Produto { get; set; }
        public int ProdutoId { get; set; }
    }
}
