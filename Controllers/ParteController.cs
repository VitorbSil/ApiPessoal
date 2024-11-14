using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPessoal.Data;
using APIPessoal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPessoal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParteController : ControllerBase
    {

        private readonly DataContext _context;

        public ParteController(DataContext context)
        {
            _context = context;
        }
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
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Parte> lista = await _context.TB_PARTES.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetParte(int id)
        {
            try
            {
                Parte p = await _context.TB_PARTES
                    .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Add(Parte novaParte)
        {
            try
            {
                await _context.TB_PARTES.AddAsync(novaParte);
                await _context.SaveChangesAsync();

                return Ok(novaParte.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Parte novaParte)
        {
            try
            {
                _context.TB_PARTES.Update(novaParte);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Parte pRemover = await _context.TB_PARTES.FirstOrDefaultAsync(p => p.Id == id);

                _context.TB_PARTES.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}