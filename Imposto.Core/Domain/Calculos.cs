using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class Calculos
    {
        public string CalculaCfop(Estado origem, Estado destino)
        {
            if (origem.Sigla == "SP" || origem.Sigla == "MG")
            {
                switch (destino.Sigla)
                {
                    case "RJ":
                        return "6.000";

                    case "PE":
                        return "6.001";

                    case "MG":
                        return "6.002";

                    case "PB":
                        return "6.003";

                    case "PR":
                        return "6.004";

                    case "PI":
                        return "6.005";

                    case "RO":
                        return "6.006";

                    case "SE":
                        return "6.009";

                    case "TO":
                        return "6.008";

                    case "PA":
                        return "6.010";

                    default:
                        return "";
                }
            }
            else
                return "";
        }

        public string CalculaTipoIcms(Estado origem, Estado destino, bool brinde)
        {
            if (origem.Sigla == destino.Sigla || brinde)
                return "60";
            else
                return "10";
        }

        public double CalculaAliquotaIcms(Estado origem, Estado destino, bool brinde)
        {
            if (origem.Sigla == destino.Sigla || brinde)
                return 0.18;
            else
                return 0.17;
        }

        public double CalculaValorIcms(double baseIcms, double aliquotaIcms)
        {
            return baseIcms * aliquotaIcms;
        }

        public double CalculaValorIpi(double baseIpi, double aliquotaIpi)
        {
            return baseIpi * aliquotaIpi;
        }

        public double CalculaAliquotaIpi(bool brinde)
        {
            if (brinde)
                return 0.0;
            else
                return 0.1;
        }

        public double CalculaDesconto(Estado estadoDestino)
        {
            if (estadoDestino.Regiao == "Sudeste")
                return 0.10;
            else
                return 0.0;
        }

        public double CalculaBaseIcms(string Cfop, double valor)
        {
            if (Cfop == "6.009")
                return valor * 0.90; //redução da base
            else
                return valor;
            
        }
    }
}
