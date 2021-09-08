using Senai_Rental_WebAPI.Domains;
using Senai_Rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data Source=DESKTOP-30RGV41\\SQLEXPRESS; initial catalog=CATALOGO_M; user id=sa; pwd=senai@132";

        //private string stringConexao = "Data Source=DESKTOP-U20H53U; initial catalog=catalogo_manha; integrated security=true";


        public void Atualizar(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Veiculo SET idEmpresa = @Empresa, idModelo = @Modelo, corVeiculo = @Cor WHERE idVeiculo =  @idVeiculo;";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@Empresa", veiculoAtualizado.empresa.idEmpresa); // 2 soluçoes, ou crio uma variavel na model ou eu instancio o objeto na model
                    cmd.Parameters.AddWithValue("@Modelo", veiculoAtualizado.modelo.idModelo);
                    cmd.Parameters.AddWithValue("@Cor", veiculoAtualizado.corVeiculo);
                    cmd.Parameters.AddWithValue("@idVeiculo", veiculoAtualizado.idVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorId(int IdVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryById = "SELECT idVeiculo, nomeEmpresa, nomeModelo, nomeMarca, corVeiculo  FROM Veiculo LEFT JOIN Empresa ON Veiculo.idEmpresa = Empresa.idEmpresa INNER JOIN Modelo ON Veiculo.idModelo = Modelo.idModelo INNER JOIN Marca ON Modelo.idMarca = Marca.idMarca WHERE idVeiculo = @idVeiculo;";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", IdVeiculo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[1].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[2].ToString(),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[3].ToString()
                                }
                            },
                            corVeiculo = rdr[4].ToString()
                        };

                        return veiculo;
                    }

                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo cliente.
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com as informações que serão cadastradas.</param>
        public void Inserir(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo(IdEmpresa, IdModelo, CorVeiculo) VALUES (@novaEmpresa, @novoModelo, @novaCor);";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novaEmpresa", novoVeiculo.empresa.idEmpresa);
                    cmd.Parameters.AddWithValue("@novoModelo", novoVeiculo.modelo.idModelo);
                    cmd.Parameters.AddWithValue("@novaCor", novoVeiculo.corVeiculo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um Cliente através do seu id
        /// </summary>
        /// <param name="idCliente">id do Cliente que será deletado</param>
        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculo WHERE idVeiculo = @id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os Clientes
        /// </summary>
        /// <returns>lista de Clientes</returns>
        public List<VeiculoDomain> ListarTodos()
        {
            List<VeiculoDomain> listaVeiculo = new List<VeiculoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectALL = "SELECT idVeiculo, nomeEmpresa, nomeModelo, nomeMarca, corVeiculo  FROM Veiculo LEFT JOIN Empresa ON Veiculo.idEmpresa = Empresa.idEmpresa INNER JOIN Modelo ON Veiculo.idModelo = Modelo.idModelo INNER JOIN Marca ON Modelo.idMarca = Marca.idMarca;";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectALL, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr[0]),
                            empresa = new EmpresaDomain()
                            {
                                nomeEmpresa = rdr[1].ToString()
                            },
                            modelo = new ModeloDomain()
                            {
                                nomeModelo = rdr[2].ToString(),
                                marca = new MarcaDomain()
                                {
                                    nomeMarca = rdr[3].ToString()
                                }
                            },
                            corVeiculo = rdr[4].ToString()
                        };

                        listaVeiculo.Add(veiculo);
                    }
                }
            }

            return listaVeiculo;
        }
    }
}