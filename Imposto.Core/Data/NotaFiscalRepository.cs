using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Domain;
using System.Data.SqlClient;
using System.Data;

namespace Imposto.Core.Data
{
    public class NotaFiscalRepository
    {
        string connectionString = @"Server=.\SQLExpress;Integrated Security = true; Initial Catalog=Teste";

        //Salva Nota Fiscal no banco de dados, executando a stored procedure P_NOTA_FISCAL passando os parâmetros para serem inseridos
        public void SalvarNotaFiscal(NotaFiscal notaFiscal)
        {
            //Adiciona uma nova Nota Fiscal no Banco de Dados executando a stored procedure P_NOTA_FISCAL e passando @pId = 0
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@pId", SqlDbType.Int).Value = 0;
                    cmd.Parameters.Add("@pNumeroNotaFiscal", SqlDbType.Int).Value = notaFiscal.NumeroNotaFiscal;
                    cmd.Parameters.Add("@pSerie", SqlDbType.Int).Value = notaFiscal.Serie;
                    cmd.Parameters.Add("@pNomeCliente", SqlDbType.VarChar).Value = notaFiscal.NomeCliente;
                    cmd.Parameters.Add("@pEstadoDestino", SqlDbType.VarChar).Value = notaFiscal.EstadoDestino.Sigla;
                    cmd.Parameters.Add("@pEstadoOrigem", SqlDbType.VarChar).Value = notaFiscal.EstadoOrigem.Sigla;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            
                //Adiciona um novo item de nota fiscal no banco de dados executando a stored procedure P_NOTA_FISCAL_ITEM e passando @pId = 0
                foreach (NotaFiscalItem item in notaFiscal.ItensDaNotaFiscal)
                {
                    using (SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL_ITEM", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@pId", SqlDbType.Int).Value = 0;
                        cmd.Parameters.Add("@pIdNotaFiscal", SqlDbType.Int).Value = item.IdNotaFiscal;
                        cmd.Parameters.Add("@pCfop", SqlDbType.VarChar).Value = item.Cfop;
                        cmd.Parameters.Add("@pTipoIcms", SqlDbType.VarChar).Value = item.TipoIcms;
                        cmd.Parameters.Add("@pBaseIcms", SqlDbType.Decimal).Value = item.BaseIcms;
                        cmd.Parameters.Add("@pAliquotaIcms", SqlDbType.Decimal).Value = item.AliquotaIcms;
                        cmd.Parameters.Add("@pValorIcms", SqlDbType.Decimal).Value = item.ValorIcms;
                        cmd.Parameters.Add("@pNomeProduto", SqlDbType.VarChar).Value = item.NomeProduto;
                        cmd.Parameters.Add("@pCodigoProduto", SqlDbType.VarChar).Value = item.CodigoProduto;
                        cmd.Parameters.Add("@pBaseIpi", SqlDbType.Decimal).Value = item.BaseIpi;
                        cmd.Parameters.Add("@pAliquotaIpi", SqlDbType.Decimal).Value = item.AliquotaIpi;
                        cmd.Parameters.Add("@pValorIpi", SqlDbType.Decimal).Value = item.ValorIpi;
                        cmd.Parameters.Add("@pDesconto", SqlDbType.Decimal).Value = item.Desconto;
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
