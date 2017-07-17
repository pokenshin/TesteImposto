using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Domain;
using System.Data.SqlClient;

namespace Imposto.Core.Data
{
    public class NotaFiscalRepository
    {
        string connectionString = @"Server=.\SQLExpress;Integrated Security = true; Initial Catalog=Teste";

        //Salva Nota Fiscal no banco de dados, executando a stored procedure P_NOTA_FISCAL passando os parâmetros para serem inseridos
        public void SalvarNotaFiscal(NotaFiscal notaFiscal)
        {
            //Adiciona uma nova Nota Fiscal no Banco de Dados
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string insertNotaFiscal = @"EXEC P_NOTA_FISCAL @pId = 0, " +
                "@pNumeroNotaFiscal = " + notaFiscal.NumeroNotaFiscal + ", " +
                "@pSerie = " + notaFiscal.Serie + ", " +
                "@pNomeCliente = " + notaFiscal.NomeCliente + ", " +
                "@pEstadoDestino = " + notaFiscal.EstadoDestino + ", " +
                "@pEstadoOrigem = " + notaFiscal.EstadoOrigem;
            SqlCommand cmd = new SqlCommand(insertNotaFiscal, conn);
            cmd.ExecuteNonQuery();


            conn.Close();
        }
    }
}
