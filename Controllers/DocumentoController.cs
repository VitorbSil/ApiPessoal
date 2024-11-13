using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIPessoal.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIPessoal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentoController : ControllerBase
    {
        private static List<Documento> documentos = new List<Documento>()
    {
        new Documento() { Id = 1, Titulo = "Contrato de Prestação de Serviços", Tipo = "Contrato", 
                          DataCriacao = new DateTime(2023, 10, 24), Status = "Ativo", 
                          Observacoes = "Contrato de prestação de serviços firmado entre as partes.", Assinado = true },
        new Documento() { Id = 2, Titulo = "Procuração", Tipo = "Procuração", 
                          DataCriacao = new DateTime(2023, 07, 08), Status = "Ativo", 
                          Observacoes = "Procuração para representação legal do cliente.", Assinado = false },
        new Documento() { Id = 3, Titulo = "Certidão de Casamento", Tipo = "Certidão", 
                          DataCriacao = new DateTime(2023, 04, 20), Status = "Ativo", 
                          Observacoes = "Certidão de casamento registrada em cartório.", Assinado = false }
    };

    // GET: api/documentos
    [HttpGet("GetAll")]
    public IActionResult Get()
    {
        return Ok(documentos);
    }

    // GET: api/documentos/{id}
    [HttpGet("{id}")]
    public ActionResult<Documento> GetDocumento(int id)
    {
        var documento = documentos.FirstOrDefault(d => d.Id == id);
        if (documento == null)
        {
            return NotFound();
        }
        return Ok(documento);
    }

    // POST: api/documentos
    [HttpPost]
    public ActionResult<Documento> PostDocumento([FromBody] Documento documento)
    {
        documento.Id = documentos.Max(d => d.Id) + 1;  // Atribui um novo ID
        documentos.Add(documento);
        return CreatedAtAction(nameof(GetDocumento), new { id = documento.Id }, documento);
    }

    // PUT: api/documentos/{id}
    [HttpPut("{id}")]
    public IActionResult PutDocumento(int id, [FromBody] Documento documentoAtualizado)
    {
        var documentoExistente = documentos.FirstOrDefault(d => d.Id == id);
        if (documentoExistente == null)
        {
            return NotFound();
        }

        documentoExistente.Titulo = documentoAtualizado.Titulo;
        documentoExistente.Tipo = documentoAtualizado.Tipo;
        documentoExistente.DataCriacao = documentoAtualizado.DataCriacao;
        documentoExistente.Status = documentoAtualizado.Status;
        documentoExistente.Observacoes = documentoAtualizado.Observacoes;
        documentoExistente.Assinado = documentoAtualizado.Assinado;

        return Ok(documentoExistente);
    }

    // DELETE: api/documentos/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteDocumento(int id)
    {
        var documento = documentos.FirstOrDefault(d => d.Id == id);
        if (documento == null)
        {
            return NotFound();
        }

        documentos.Remove(documento);
        return Ok(documentos);
    }
    }
}