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
    public class ParteController : ControllerBase
    {
        private static List<Parte> partes = new List<Parte>()
    {
        new Parte() { Id = 1, Nome = "Vitor", Tipo = "Cliente", DocumentoIdentidade = "RG", 
                      Endereco = "Rua 1, Bairro A, Cidade X", Telefone = "1234-5678", Email = "vitor@email.com" },
        new Parte() { Id = 2, Nome = "Ana", Tipo = "Advogado", DocumentoIdentidade = "OAB", 
                      Endereco = "Rua 2, Bairro B, Cidade Y", Telefone = "2345-6789", Email = "ana@adv.com" },
        new Parte() { Id = 3, Nome = "Carlos", Tipo = "Testemunha", DocumentoIdentidade = "CPF", 
                      Endereco = "Rua 3, Bairro C, Cidade Z", Telefone = "3456-7890", Email = "carlos@teste.com" }
    };

    [HttpGet("GetAll")]
    public IActionResult Get()
    {
        return Ok(partes);
    }

    [HttpGet("{id}")]
    public ActionResult<Parte> GetParte(int id)
    {
        var parte = partes.FirstOrDefault(p => p.Id == id);
        if (parte == null)
        {
            return NotFound();
        }
        return Ok(parte);
    }

    [HttpPost]
    public ActionResult<Parte> PostParte([FromBody] Parte parte)
    {
        parte.Id = partes.Max(p => p.Id) + 1;  // Atribui um novo ID
        partes.Add(parte);
        return Ok(partes);
    }

    [HttpPut("{id}")]
    public IActionResult PutParte(int id, [FromBody] Parte parteAtualizada)
    {
        var parteExistente = partes.FirstOrDefault(p => p.Id == id);
        if (parteExistente == null)
        {
            return NotFound();
        }

        parteExistente.Nome = parteAtualizada.Nome;
        parteExistente.Tipo = parteAtualizada.Tipo;
        parteExistente.DocumentoIdentidade = parteAtualizada.DocumentoIdentidade;
        parteExistente.Endereco = parteAtualizada.Endereco;
        parteExistente.Telefone = parteAtualizada.Telefone;
        parteExistente.Email = parteAtualizada.Email;

        return Ok(partes);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteParte(int id)
    {
        var parte = partes.FirstOrDefault(p => p.Id == id);
        if (parte == null)
        {
            return NotFound();
        }

        partes.Remove(parte);
        return Ok(partes);
    }
    }
}