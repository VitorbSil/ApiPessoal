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
    public class ContratoController : ControllerBase
    {

        private readonly DataContext _context;

        public ContratoController(DataContext context)
        {
            _context = context;
        }
        private static List<Contrato> contratos = new List<Contrato>()
        {
            new Contrato() {Id = 1, Titulo = "Primeiro Contrato", DataInicio = new DateTime(2023, 10, 24), DataFim = new DateTime(2024, 10, 24),
            Status = "Ativo", Cliente = "ETEC", Prestador = "EscritórioX", Valor = 1300, ParteId = 1},
            new Contrato() {Id = 2, Titulo = "Segundo Contrato", DataInicio = new DateTime(2023, 07, 08), DataFim = new DateTime(2024, 07, 08),
            Status = "Desativado", Cliente = "Casa de Bolo", Prestador = "EscritórioY", Valor = 2500, ParteId = 2},
            new Contrato() {Id = 3, Titulo = "Terceiro Contrato", DataInicio = new DateTime(2023, 04, 20), DataFim = new DateTime(2024, 04, 20),
            Status = "Ativo", Cliente = "Mercadinho", Prestador = "EscritórioZ", Valor = 800, ParteId = 3}
        };

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Contrato c = contratos[0];
            return Ok(c);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Contrato> lista = await _context.TB_CONTRATOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetContrato(int id)
        {
            try
            {
                Contrato c = await _context.TB_CONTRATOS
                    .FirstOrDefaultAsync(cBusca => cBusca.Id == id);

                return Ok(c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Add(Contrato novoContrato)
        {
            try
            {
                await _context.TB_CONTRATOS.AddAsync(novoContrato);
                await _context.SaveChangesAsync();

                return Ok(novoContrato.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(Contrato novoContrato)
        {
           try
           {
                _context.TB_CONTRATOS.Update(novoContrato);
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
                Contrato cRemover = await _context.TB_CONTRATOS.FirstOrDefaultAsync(c => c.Id == id);

                _context.TB_CONTRATOS.Remove(cRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();

                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest ( ex.Message);
            }
        }











    }
}