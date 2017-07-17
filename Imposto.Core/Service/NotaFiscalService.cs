using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {
        public void GerarNotaFiscal(Domain.Pedido pedido)
        {
            NotaFiscal notaFiscal = new NotaFiscal();
            notaFiscal.EmitirNotaFiscal(pedido);
            criarXML(notaFiscal);
        }

        //Gera XML com os dados da nota fiscal
        private void criarXML(NotaFiscal notaFiscal)
        {
            //Caminho onde o arquivo XML vai ser salvo.
            String caminho = @"C:\Temp\NotaFiscal\";

            //Nome do arquivo no formato NF_ ano + mês + dia + _ + Hora + minutos + segundos + milésimos
            String arquivo = "NF_" + DateTime.Now.ToString("yyyyMMdd_Hmmssffff") + ".xml";

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
    }
}
