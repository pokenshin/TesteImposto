using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    [Serializable]
    public class Estado
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public string Regiao { get; set; }
  
        public Estado()
        {
        }

        public Estado(string sigla)
        {
            this.Sigla = sigla;
            this.Nome = "";
            this.Regiao = "";
        }

        public Estado(string sigla, string nome, string regiao) : this(sigla)
        {
            this.Sigla = sigla;
            this.Nome = nome;
            this.Regiao = regiao;
        }
    }
}
