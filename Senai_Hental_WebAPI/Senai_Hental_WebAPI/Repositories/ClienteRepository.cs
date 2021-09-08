using Senai_Rental_WebAPI.Domains;
using Senai_Rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private string stringConexao = "Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; integrated security=true";


        public void Atualizar(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE CLIENTE SET nomeCliente = @novoNomeCliente WHERE idCliente = @idClienteAtualizado";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@novoNomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@idClienteAtualizado", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            nomeCliente = reader["nomeCliente"].ToString(),

                            sobrenomeCliente = reader["sobrenomeCliente"].ToString(),

                            cpf = reader["CPF"].ToString()
                        };

                        return clienteBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo cliente.
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com as informações que serão cadastradas.</param>
        public void Inserir(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {

                string queryInsert = "INSERT INTO Cliente(nomeCliente, sobrenomeCliente, CPF) VALUES (@nomeCliente, @sobrenomeCliente, @CPF);";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {

                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@CPF", novoCliente.cpf);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um Cliente através do seu id
        /// </summary>
        /// <param name="idCliente">id do Cliente que será deletado</param>
        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os Clientes
        /// </summary>
        /// <returns>lista de Clientes</returns>
        public List<ClienteDomain> ListarTodos()
        {
            List<ClienteDomain> listaCliente = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT * FROM Cliente;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain Cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),

                            nomeCliente = rdr[1].ToString(),

                            sobrenomeCliente = rdr[2].ToString(),

                            cpf = rdr[3].ToString(),
                        };

                        listaCliente.Add(Cliente);
                    }
                }
            }

            return listaCliente;
        }
    }
}