using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Domains
{
    public class ModeloDomain
    {
        public int idModelo;
        public MarcaDomain Marca;
        public string nomeModelo;
        public DateTime anoLancamento;
    }
}
