using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPessoal.Models
{
    public class Parte
    {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Tipo { get; set; }  // Ex: "Cliente", "Fornecedor", "Advogado"
    public string DocumentoIdentidade { get; set; }  // RG, CPF, CNPJ, etc.
    public string Endereco { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }

    public List<Documento> Documentos {get; set;} = new List<Documento>();

    public Contrato Contrato {get; set;}
    }
}