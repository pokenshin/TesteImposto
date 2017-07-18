using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    [Serializable]
    public class NotaFiscal
    {
        public int Id { get; set; }
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }

        public Estado EstadoDestino { get; set; }
        public Estado EstadoOrigem { get; set; }

        public List<NotaFiscalItem> ItensDaNotaFiscal { get; set; }

        public NotaFiscal()
        {
            ItensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        public void EmitirNotaFiscal(Pedido pedido)
        {
            this.NumeroNotaFiscal = 99999;
            this.Serie = new Random().Next(Int32.MaxValue);
            this.NomeCliente = pedido.NomeCliente;

            this.EstadoDestino = pedido.EstadoDestino;
            this.EstadoOrigem = pedido.EstadoOrigem;

            Calculos calculos = new Calculos();

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

                //Campos calculados
                notaFiscalItem.Cfop = calculos.CalculaCfop(pedido.EstadoOrigem, pedido.EstadoDestino);
                notaFiscalItem.TipoIcms = calculos.CalculaTipoIcms(pedido.EstadoOrigem, pedido.EstadoDestino, itemPedido.Brinde);
                notaFiscalItem.AliquotaIcms = calculos.CalculaAliquotaIcms(pedido.EstadoOrigem, pedido.EstadoDestino, itemPedido.Brinde);
                notaFiscalItem.BaseIcms = calculos.CalculaBaseIcms(notaFiscalItem.Cfop, itemPedido.ValorItemPedido);
                notaFiscalItem.ValorIcms = calculos.CalculaValorIcms(notaFiscalItem.BaseIcms, notaFiscalItem.AliquotaIcms);
                notaFiscalItem.AliquotaIpi = calculos.CalculaAliquotaIpi(itemPedido.Brinde);
                notaFiscalItem.ValorIpi = calculos.CalculaValorIpi(notaFiscalItem.BaseIpi, notaFiscalItem.AliquotaIpi);
                notaFiscalItem.Desconto = calculos.CalculaDesconto(pedido.EstadoDestino);
                //Campos fixos
                notaFiscalItem.BaseIpi = itemPedido.ValorItemPedido;
                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;
                
                ItensDaNotaFiscal.Add(notaFiscalItem);
            }            
        }
    }
}
