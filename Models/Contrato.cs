using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPessoal.Models
{
    public class Contrato
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string Status { get; set; }
        public string Cliente { get; set; }
        public string Prestador { get; set; }
        public decimal Valor { get; set; }

        public Parte Parte { get; set; }

        public int ParteId { get; set; }
    }
}