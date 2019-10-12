using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Models
{
    public class ModalDeletar
    {
        public string UrlPost { get; set; }
        public string Valor { get; set; }
        public string UrlCallback { get; set; }
        public string NomeTitulo { get; set; }

        public bool ValidarCamposDeletar()
        {
            return !string.IsNullOrEmpty(UrlPost) && !string.IsNullOrEmpty(Valor) && !string.IsNullOrEmpty(UrlCallback);
        }
    }
}
