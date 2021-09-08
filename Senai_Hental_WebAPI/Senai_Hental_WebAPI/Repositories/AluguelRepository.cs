using Senai_Rental_WebAPI.Domains;
using Senai_Rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {   /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source = Nome do Servidor
        /// inital catalog = Nome do banco de dados
        /// user id= sa; pwd= Senai@132 = Faz a autenticação com o SQL SERVER, passando Login e Senha.
        /// integrated security = Faz a autenticação com o usuario do sistema (Windows).
        /// </summary>
        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; user id=sa; pwd=Senai@132";
        private string stringConexao = "Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; integrated security=true";

        public void Atualizar(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Aluguel SET idVeiculo = @novoVeiculo, idCliente = @novoCliente, dataRetirada = @novaDataRetirada, dataDevolucao = @novaDataDevolucao WHERE idAluguel = @idAluguel;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@novoVeiculo", aluguelAtualizado.veiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@novoCliente", aluguelAtualizado.cliente.idCliente);
                    cmd.Parameters.AddWithValue("@novaDataRetirada", aluguelAtualizado.dataRetirada);
                    cmd.Parameters.AddWithValue("@novaDataDevolucao", aluguelAtualizado.dataDevolucao);
                    cmd.Parameters.AddWithValue("@idAluguel", aluguelAtualizado.idAluguel);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, nomeCliente, sobrenomeCliente, nomeModelo, corVeiculo, dataRetirada, dataDevolucao FROM Aluguel INNER JOIN Cliente ON Aluguel.idCliente = Cliente.idCliente INNER JOIN Veiculo ON Aluguel.idVeiculo = Veiculo.idVeiculo INNER JOIN Modelo ON Veiculo.idModelo = Modelo.idModelo WHERE idAluguel = @Aluguel;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    rdr = cmd.ExecuteReader();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            cliente = new ClienteDomain()
                            {
                                nomeCliente = rdr[1].ToString(),
                                sobrenomeCliente = rdr[2].ToString()
                            },
                            veiculo = new VeiculoDomain()
                            {
                                modelo = new ModeloDomain()
                                {
                                    nomeModelo = rdr[3].ToString()
                                },
                                corVeiculo = rdr[4].ToString()
                            },
                            dataRetirada = Convert.ToDateTime(rdr[5]),
                            dataDevolucao = Convert.ToDateTime(rdr[6])
                        };

                        return aluguelBuscado;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo cliente.
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com as informações que serão cadastradas.</param>
        public void Inserir(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel(idVeiculo, idCliente, dataRetirada, dataDevolucao) VALUES (@novoVeiculo, @novoCliente, @novaDataRetirada, @novaDataDevolucao);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novoVeiculo", novoAluguel.veiculo.idVeiculo);
                    cmd.Parameters.AddWithValue("@novoCliente", novoAluguel.cliente.idCliente);
                    cmd.Parameters.AddWithValue("@novaDataRetirada", novoAluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@novaDataDevolucao", novoAluguel.dataDevolucao);

                    cmd.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// Deleta um Cliente através do seu id
        /// </summary>
        /// <param name="idCliente">id do Cliente que será deletado</param>
        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Aluguel WHERE idAluguel = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os Clientes
        /// </summary>
        /// <returns>lista de Clientes</returns>
        public List<AluguelDomain> ListarTodos()
        {
            List<AluguelDomain> listaAluguel = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idAluguel, DataRetirada, DataDevolucao, NomeCliente, SobrenomeCliente, NomeModelo FROM Aluguel LEFT JOIN Cliente ON Aluguel.IdCliente = Cliente.IdCliente LEFT JOIN Veiculo ON Aluguel.IdVeiculo = Veiculo.IdVeiculo LEFT JOIN Modelo ON Veiculo.IdModelo = Modelo.IdModelo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain Aluguel = new AluguelDomain()
                        {
                            dataRetirada = Convert.ToDateTime(rdr[0]),

                            dataDevolucao = Convert.ToDateTime(rdr[1]),

                            cliente = new ClienteDomain
                            {
                                nomeCliente = rdr[2].ToString(),
                                sobrenomeCliente = rdr[3].ToString(),
                            },

                            veiculo = new VeiculoDomain
                            {
                                modelo = new ModeloDomain
                                {
                                    nomeModelo = rdr[4].ToString()
                                }
                            }
                        };

                        listaAluguel.Add(Aluguel);
                    }
                }
            }

            return listaAluguel;
        }
    }
}