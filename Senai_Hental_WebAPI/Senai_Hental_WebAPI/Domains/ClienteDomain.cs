using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Domains
{
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }
        public int CPF { get; set; }
    }
}
