using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Imposto.Core.Domain;

namespace Imposto.Test
{
    [TestClass]
    public class CalculosTeste
    {
        Calculos calculos = new Calculos();

        //Testes para o método CalculaTipoIcms

        //Calcula o tipo de ICMS para estados iguais sem brinde
        //Resultado Esperado =  "60"
        [TestMethod]
        public void TestaCalculaTipoIcmsEstadosIguaisSemBrinde()
        {
            Estado origem = new Estado("SP", "São Paulo", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            string resultado = calculos.CalculaTipoIcms(origem, destino, false);
            Assert.AreEqual("60", resultado);
        }

        //Calcula o tipo de ICMS para estados iguais com brinde
        //Resultado Esperado =  "60"
        [TestMethod]
        public void TestaCalculaTipoIcmsEstadosIguaisComBrinde()
        {
            Estado origem = new Estado("SP", "São Paulo", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            string resultado = calculos.CalculaTipoIcms(origem, destino, true);
            Assert.AreEqual("60", resultado);
        }

        //Calcula o tipo de ICMS para estados diferentes com brinde
        //Resultado Esperado =  "60"
        [TestMethod]
        public void TestaCalculaTipoIcmsEstadosDiferentesComBrinde()
        {
            Estado origem = new Estado("RJ", "Rio de Janeiro", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            string resultado = calculos.CalculaTipoIcms(origem, destino, true);
            Assert.AreEqual("60", resultado);
        }

        //Calcula o tipo de ICMS para estados diferentes com brinde
        //Resultado Esperado =  "10"
        [TestMethod]
        public void TestaCalculaTipoIcmsEstadosDiferentesSemBrinde()
        {
            Estado origem = new Estado("RJ", "Rio de Janeiro", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            string resultado = calculos.CalculaTipoIcms(origem, destino, false);
            Assert.AreEqual("10", resultado);
        }


        //Testes para o método CalculaAliquotaIcms

        //Calcula a aliquota do ICMS para estados iguais sem brinde
        //Resultado Esperado =  0.18
        [TestMethod]
        public void TestaCalculaAliquotaIcmsEstadosIguaisSemBrinde()
        {
            Estado origem = new Estado("SP", "São Paulo", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            double resultado = calculos.CalculaAliquotaIcms(origem, destino, false);
            Assert.AreEqual(0.18, resultado);
        }

        //Calcula a aliquota do ICMS para estados iguais sem brinde
        //Resultado Esperado =  0.18
        [TestMethod]
        public void TestaCalculaAliquotaIcmsEstadosIguaisComBrinde()
        {
            Estado origem = new Estado("SP", "São Paulo", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            double resultado = calculos.CalculaAliquotaIcms(origem, destino, true);
            Assert.AreEqual(0.18, resultado);
        }

        //Calcula a aliquota do ICMS para estados diferentes sem brinde
        //Resultado Esperado =  0.17
        [TestMethod]
        public void TestaCalculaAliquotaIcmsEstadosDiferentesSemBrinde()
        {
            Estado origem = new Estado("RJ", "Rio de Janeiro", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            double resultado = calculos.CalculaAliquotaIcms(origem, destino, false);
            Assert.AreEqual(0.17, resultado);
        }

        //Calcula a aliquota do ICMS para estados diferentes com brinde
        //Resultado Esperado =  0.18
        [TestMethod]
        public void TestaCalculaAliquotaIcmsEstadosDiferentesComBrinde()
        {
            Estado origem = new Estado("RJ", "Rio de Janeiro", "Sudeste");
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            double resultado = calculos.CalculaAliquotaIcms(origem, destino, true);
            Assert.AreEqual(0.18, resultado);
        }

        //Testes para o método CalculaValorIcms

        //Calcula o valor do ICMS para baseIcms = 1000 e aliquotaIcms = 0.18
        //Resultado Esperado =  baseIcms * aliquotaIcms = 1000 * 0.18 = 180
        [TestMethod]
        public void TestaCalculaValorIcms()
        {
            double baseIcms = 1000;
            double aliquotaIcms = 0.18;
            double resultado = calculos.CalculaValorIcms(baseIcms, aliquotaIcms);
            Assert.AreEqual(180, resultado);
        }

        //Testes para o método CalculaValorIpi

        //Calcula o valor do IPI para baseIPI = 1000 e aliquotaIpi = 0.1
        //Resultado Esperado = baseIPI * aliquotaIpi = 1000 * 0.1 = 100
        [TestMethod]
        public void TestaCalculaValorIpi()
        {
            double baseIpi = 1000;
            double aliquotaIpi = 0.1;
            double resultado = calculos.CalculaValorIpi(baseIpi, aliquotaIpi);
            Assert.AreEqual(100, resultado);
        }

        //Testes para o método CalculaAliquotaIpi

        //Calcula a Aliquota do IPI com brinde
        //Resultado esperado = 0.0
        [TestMethod]
        public void TestaCalculaAliquotaIpiComBrinde()
        {
            double resultado = calculos.CalculaAliquotaIpi(true);
            Assert.AreEqual(0.0, resultado);
        }

        //Calcula a Aliquota do IPI sem brinde
        //Resultado esperado = 0.1
        [TestMethod]
        public void TestaCalculaAliquotaIpiSemBrinde()
        {
            double resultado = calculos.CalculaAliquotaIpi(false);
            Assert.AreEqual(0.1, resultado);
        }

        //Testes para o método CalculaDesconto

        //Calcula desconto para estados do Sudeste
        //Resultado esperado = 0.10
        [TestMethod]
        public void TestaCalculaDescontoEstadosSudeste()
        {
            Estado destino = new Estado("SP", "São Paulo", "Sudeste");
            double resultado = calculos.CalculaDesconto(destino);
            Assert.AreEqual(0.10, resultado);
        }

        //Calcula desconto para estados que não são do Sudeste
        //Resultado esperado = 0.0
        [TestMethod]
        public void TestaCalculaDescontoEstadosNaoSudeste()
        {
            Estado destino = new Estado("RS", "Rio Grande do Sul", "Sul");
            double resultado = calculos.CalculaDesconto(destino);
            Assert.AreEqual(0.0, resultado);
        }

        //Testes para o método CalculaBaseIcms

        //Calcula base do ICMS para Cfop = 6.009 e valor 10000
        //Resultado esperado = 10000 * 0.9 = 9000
        [TestMethod]
        public void TestaCalculaBaseIcmsCfopSeisMilENove()
        {
            double resultado = calculos.CalculaBaseIcms("6.009", 10000);
            Assert.AreEqual(9000, resultado);
        }

        //Calcula base do ICMS para Cfop diferente de 6.009 e valor 10000
        //Resultado esperado = 10000
        [TestMethod]
        public void TestaCalculaBaseIcmsQualquerCfop()
        {
            double resultado = calculos.CalculaBaseIcms("6.003", 10000);
            Assert.AreEqual(10000, resultado);
        }

    }
}
