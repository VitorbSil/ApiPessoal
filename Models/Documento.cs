using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPessoal.Models
{
    public class Documento
    {
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Tipo { get; set; }  // Ex: "Procuradoria", "Petição Inicial"
    public DateTime DataCriacao { get; set; }
    public string Status { get; set; }  // Ex: "Em andamento", "Concluído"
    public string Observacoes { get; set; }
    public bool Assinado { get; set; }  // Indica se o documento foi assinado
    }
}