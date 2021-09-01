using Senai_Rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Interfaces
{
    /// <sumary>
    /// Interface responsável pelo repositório AluguelRepository
    /// </sumary>
    interface IAluguelRepository
    {
        /// <sumary>
        /// Retorna uma lista de aluguéis
        /// </sumary>
        /// <returns> Uma lista de aluguéis </returns>
        List<AluguelDomain> ListarTodos();

        /// <sumary>
        /// Busca um aluguel através do seu id
        /// </sumary>
        /// <param name="idAluguel">id do aluguel que será buscado</param>
        /// <returns>Um objeto do tipo AluguelDomain que foi buscado</returns>
        AluguelDomain BuscarPorId(int idAluguel);


        /// <summary>
        /// Cadastra um aluguel novo
        /// </summary>
        /// <param name="novoAluguel">Objeto novoGenero com os dados que serão cadastrados</param>
        void Cadastrar(AluguelDomain novoAluguel);

        /// <summary>
        /// Atualiza um aluguel existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idAluguel">id do gênero que será atualizado</param>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/aluguel
        void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado);

        /// <summary>
        /// Deleta um alugeul
        /// </summary>
        /// <param name="idAluguel">id do aluguel que será deletado</param>
        void Deletar(int idAluguel);
    }

}
