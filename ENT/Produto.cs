using System;
using System.Collections.Generic;

namespace ENT
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual List<Imagem> Imagens { get; set; }

    }
}
