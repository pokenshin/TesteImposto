﻿using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imposto.Core.Domain;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private Pedido pedido = new Pedido();
        private List<Estado> estados = new List<Estado>();

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;                       
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();
            geraEstados(); //Gera lista de estados
            populaCombosEstados(); //Popula comboboxes com os estados gerados
        }

        private void populaCombosEstados()
        {
            BindingSource bsDestinos = new BindingSource();
            BindingSource bsOrigens = new BindingSource();
            bsDestinos.DataSource = estados;
            bsOrigens.DataSource = estados;
            cbbDestino.DataSource = bsDestinos;
            cbbOrigem.DataSource = bsOrigens;
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }   
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));
                     
            return table;
        }

        private List<Estado> geraEstados()
        {
            estados.Add(new Estado("AC", "Acre", "Norte"));
            estados.Add(new Estado("AL", "Alagoas", "Nordeste"));
            estados.Add(new Estado("AP", "Amapá", "Norte"));
            estados.Add(new Estado("AM", "Amazonas", "Norte"));
            estados.Add(new Estado("BA", "Bahia", "Nordeste"));
            estados.Add(new Estado("CE", "Ceará", "Nordeste"));
            estados.Add(new Estado("DF", "Distrito Federal", "Centro-Oeste"));
            estados.Add(new Estado("ES", "Espírito Santo", "Sudeste"));
            estados.Add(new Estado("GO", "Goiás", "Centro-Oeste"));
            estados.Add(new Estado("MA", "Maranhão", "Nordeste"));
            estados.Add(new Estado("MT", "Mato Grosso", "Centro-Oeste"));
            estados.Add(new Estado("MS", "Mato Grosso do Sul", "Centro-Oeste"));
            estados.Add(new Estado("MG", "Minas Gerais", "Sudeste"));
            estados.Add(new Estado("PA", "Pará", "Norte"));
            estados.Add(new Estado("PB", "Paraíba", "Nordeste"));
            estados.Add(new Estado("PR", "Paraná", "Sul"));
            estados.Add(new Estado("PE", "Pernambuco", "Nordeste"));
            estados.Add(new Estado("PI", "Piauí", "Nordeste"));
            estados.Add(new Estado("RJ", "Rio de Janeiro", "Sudeste"));
            estados.Add(new Estado("RN", "Rio Grande do Norte", "Nordeste"));
            estados.Add(new Estado("RS", "Rio Grande do Sul", "Sul"));
            estados.Add(new Estado("RO", "Rondônia", "Norte"));
            estados.Add(new Estado("RR", "Roraima", "Norte"));
            estados.Add(new Estado("SC", "Santa Catarina", "Sul"));
            estados.Add(new Estado("SP", "São Paulo", "Sudeste"));
            estados.Add(new Estado("SE", "Sergipe", "Nordeste"));
            estados.Add(new Estado("TO", "Tocantins", "Norte"));

            return estados;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {            
            NotaFiscalService service = new NotaFiscalService();
            pedido.EstadoOrigem = cbbOrigem.SelectedValue as Estado;
            pedido.EstadoDestino = cbbDestino.SelectedValue as Estado;
            pedido.NomeCliente = textBoxNomeCliente.Text;

            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            foreach (DataRow row in table.Rows)
            {
                //Caso o usuário não tenha checado a checkbox "Brinde", atribuir o valor "false" manualmente
                //Necessário pois caso o usuário não clique na checkbox, o valor correspondente da DataColumn vira "null" e gera um erro ao adiciona-lo em ItensDoPedido
                if (row.IsNull("Brinde"))
                    row["Brinde"] = false;

                pedido.ItensDoPedido.Add(
                    new PedidoItem()
                    {
                        Brinde = Convert.ToBoolean(row["Brinde"]),
                        CodigoProduto =  row["Codigo do produto"].ToString(),
                        NomeProduto = row["Nome do produto"].ToString(),
                        ValorItemPedido = Convert.ToDouble(row["Valor"].ToString())            
                    });
            }

            service.GerarNotaFiscal(pedido);
            MessageBox.Show("Operação efetuada com sucesso");
        }
    }
}
