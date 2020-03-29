
using Application.Queries.Empresas.Models;
using System.Collections.Generic;

namespace Application.Queries.Empresas.GetAll
{
    public sealed class ObterTodasEmpresasQueryResult
    {
        public List<EmpresaResult> Empresas { get; set; }

        public ObterTodasEmpresasQueryResult()
        {
            Empresas = new List<EmpresaResult>();
        }
    }
}