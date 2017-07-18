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
        private string[] siglasValidas = new string[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

        public Estado()
        {
        }

        public Estado(string sigla)
        {
            switch (sigla)
            {
                case "AC":
                    this.Nome = "Acre";
                    this.Regiao = "Norte";
                    break;

                case "AL":
                    this.Nome = "Alagoas";
                    this.Regiao = "Nordeste";
                    break;

                case "AP":
                    this.Nome = "Amapá";
                    this.Regiao = "Norte";
                    break;

                case "AM":
                    this.Nome = "Amazonas";
                    this.Regiao = "Norte";
                    break;

                case "BA":
                    this.Nome = "Bahia";
                    this.Regiao = "Nordeste";
                    break;

                case "CE":
                    this.Nome = "Ceará";
                    this.Regiao = "Nordeste";
                    break;

                case "DF":
                    this.Nome = "Distrito Federal";
                    this.Regiao = "Centro-Oeste";
                    break;

                case "ES":
                    this.Nome = "Espírito Santo";
                    this.Regiao = "Sudeste";
                    break;

                case "GO":
                    this.Nome = "Goiás";
                    this.Regiao = "Centro-Oeste";
                    break;

                case "MA":
                    this.Nome = "Maranhão";
                    this.Regiao = "Nordeste";
                    break;

                case "MT":
                    this.Nome = "Mato Grosso";
                    this.Regiao = "Centro-Oeste";
                    break;

                case "MS":
                    this.Nome = "Mato Grosso do Sul";
                    this.Regiao = "Centro-Oeste";
                    break;

                case "MG":
                    this.Nome = "Minas Gerais";
                    this.Regiao = "Sudeste";
                    break;

                case "PA":
                    this.Nome = "Pará";
                    this.Regiao = "Norte";
                    break;

                case "PB":
                    this.Nome = "Paraíba";
                    this.Regiao = "Nordeste";
                    break;

                case "PR":
                    this.Nome = "Paraná";
                    this.Regiao = "Sul";
                    break;

                case "PE":
                    this.Nome = "Pernambuco";
                    this.Regiao = "Nordeste";
                    break;

                case "PI":
                    this.Nome = "Piauí";
                    this.Regiao = "Nordeste";
                    break;

                case "RJ":
                    this.Nome = "Rio de Janeiro";
                    this.Regiao = "Sudeste";
                    break;

                case "RN":
                    this.Nome = "Rio Grande do Norte";
                    this.Regiao = "Nordeste";
                    break;

                case "RS":
                    this.Nome = "Rio Grande do Sul";
                    this.Regiao = "Sul";
                    break;

                case "RO":
                    this.Nome = "Rondônia";
                    this.Regiao = "Norte";
                    break;

                case "RR":
                    this.Nome = "Roraima";
                    this.Regiao = "Norte";
                    break;

                case "SC":
                    this.Nome = "Santa Catarina";
                    this.Regiao = "Sul";
                    break;

                case "SP":
                    this.Nome = "São Paulo";
                    this.Regiao = "Sudeste";
                    break;

                case "SE":
                    this.Nome = "Sergipe";
                    this.Regiao = "Nordeste";
                    break;

                case "TO":
                    this.Nome = "Tocantins";
                    this.Regiao = "Norte";
                    break;

                default:
                    return;
            }

            this.Sigla = sigla;
        }
    }
}
