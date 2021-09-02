using Senai_Rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Interfaces
{
    /// <sumary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </sumary>
    interface IVeiculoRepository
    {
        /// <sumary>
        /// Retorna uma lista de veiculos
        /// </sumary>
        /// <returns> Uma lista de veiculos </returns>
        List<VeiculoDomain> ListarTodos();

        /// <sumary>
        /// Busca um aluguel através do seu id
        /// </sumary>
        /// <param name="idVeiculo">id do veiculo que será buscado</param>
        /// <returns>Um objeto do tipo VeiculolDomain que foi buscado</returns>
        VeiculoDomain BuscarPorId(int idVeiculo);


        /// <summary>
        /// Cadastra um veiculo novo
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo com os dados que serão cadastrados</param>
        void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Atualiza um veiculo existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será atualizado</param>
        /// <param name="VeiculoAtualizado">Objeto veiculoAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/veiculo
        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// Deleta um veiculo
        /// </summary>
        /// <param name="idVeiculo">id do veiculo que será deletado</param>
        void Deletar(int idVeiculo);
    }
}
