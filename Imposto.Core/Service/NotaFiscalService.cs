using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Imposto.Core.Data;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {
        //Caminho onde o arquivo XML vai ser salvo.
        private string caminho = @"C:\Temp\NotaFiscal\";

        //Nome do arquivo no formato NF_ ano + mês + dia + _ + Hora + minutos + segundos + milésimos
        private string arquivo;

        public void GerarNotaFiscal(Domain.Pedido pedido)
        {
            NotaFiscal notaFiscal = new NotaFiscal();
            notaFiscal.EmitirNotaFiscal(pedido);
            criarXML(notaFiscal);
            //insereBD(notaFiscal);
        }

        //Gera XML com os dados da nota fiscal
        private void criarXML(NotaFiscal notaFiscal)
        {
            //Gera o nome do arquivo
            arquivo = "NF_" + DateTime.Now.ToString("yyyyMMdd_Hmmssffff") + ".xml";

            //Criar diretório caso ele não exista
            if (!Directory.Exists(caminho))
                Directory.CreateDirectory(caminho);

            //Serializa o objeto notaFiscal em um arquivo XML e salva no caminho solicitado
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(notaFiscal.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, notaFiscal);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(caminho + arquivo);
                    stream.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao gerar XML: " + ex);

            }
        }

        // Insere a nota fiscal no banco de dados
        private void insereBD(NotaFiscal notaFiscal)
        {
            //Somente insere no banco de dados caso o arquivo XML já exista.
            if (!File.Exists(caminho + arquivo))
                return;
            else
            {
                NotaFiscalRepository repositorio = new NotaFiscalRepository();
                repositorio.SalvarNotaFiscal(notaFiscal);
            }
        }
    }
}
