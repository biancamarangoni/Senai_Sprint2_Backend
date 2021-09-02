using Senai_Rental_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Repositories
{
    public class AluguelRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source = Nome do Servidor
        /// inital catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando Login e Senha.
        /// integrated security = Faz a autenticação com o usuario do sistema (Windows).
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";
        private string stringConexao = "Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; integrated security=true";

        public void AtualizarIdCorpo(AluguelDomain aluguelAtualizado)
        {
            if(aluguelAtualizado.dataRetirada != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE ALUGUEL SET dataRetirada = @novaDataAlu WHERE idAluguel = @idAluAtualizado";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@novaDataAlu", aluguelAtualizado.nomeAluguel);
                        cmd.Parameters.AddWithValue("@idAluAtualizado", aluguelAtualizado.idAluguel);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
