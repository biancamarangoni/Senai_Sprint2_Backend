using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Rental_WebAPI.Domains
{
    public class VeiculoDomain
    {
        public int idVeiculo;
        public EmpresaDomain Empresa;
        public ModeloDomain Modelo;
        public string corVeiculo;
    }
}
