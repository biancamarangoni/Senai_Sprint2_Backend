using Senai_Rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Interfaces
{
    /// <sumary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </sumary>
    interface IClienteRepository
    {
        /// <sumary>
        /// Retorna uma lista de clientes
        /// </sumary>
        /// <returns> Uma lista de clientes </returns>
        List<ClienteDomain> ListarTodos();

        /// <sumary>
        /// Busca um cliente através do seu id
        /// </sumary>
        /// <param name="idCliente">id do cliente que será buscado</param>
        /// <returns>Um objeto do tipo ClienteDomain que foi buscado</returns>
        ClienteDomain BuscarPorId(int idCliente);


        /// <summary>
        /// Cadastra um cliente novo
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente com os dados que serão cadastrados</param>
        void Cadastrar(ClienteDomain novoCliente);

        /// <summary>
        /// Atualiza um cliente existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="idCliente">id do cliente que será atualizado</param>
        /// <param name="ClienteAtualizado">Objeto clienteAtualizado com os novos dados</param>
        /// ex: http://localhost:5000/api/cliente
        void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado);

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="idCliente">id do cliente que será deletado</param>
        void Deletar(int idCliente);
    }
}
