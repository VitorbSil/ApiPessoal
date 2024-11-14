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
    public class DocumentoController : ControllerBase
    {

        private readonly DataContext _context;

        public DocumentoController(DataContext context)
        {
            _context = context;
        }
        private static List<Documento> documentos = new List<Documento>()
    {
        new Documento() { Id = 1, Titulo = "Contrato de Prestação de Serviços", Tipo = "Contrato",
                          DataCriacao = new DateTime(2023, 10, 24), Status = "Ativo",
                          Observacoes = "Contrato de prestação de serviços firmado entre as partes.", Assinado = true, ParteId = 1 },

        new Documento() { Id = 2, Titulo = "Procuração", Tipo = "Procuração",
                          DataCriacao = new DateTime(2023, 07, 08), Status = "Ativo",
                          Observacoes = "Procuração para representação legal do cliente.", Assinado = true, ParteId = 1 },

        new Documento() { Id = 3, Titulo = "Certidão de Casamento", Tipo = "Certidão",
                          DataCriacao = new DateTime(2023, 04, 20), Status = "Ativo",
                          Observacoes = "Certidão de casamento registrada em cartório.", Assinado = false, ParteId = 1 },
                          
        new Documento() { Id = 4, Titulo = "Alvará de Soltura", Tipo = "Alvará",
                          DataCriacao = new DateTime(2024, 11, 01), Status = "Pendente",
                          Observacoes = "Alvará de Soltura esperando análise do Juiz.", Assinado = false, ParteId = 3 },

        new Documento() { Id = 5, Titulo = "Petição de Invertário", Tipo = "Petição",
                          DataCriacao = new DateTime(2021, 01, 01), Status = "Ativo",
                          Observacoes = "Petição cadastrada e enviada para o Juiz.", Assinado = true, ParteId = 3 },

        new Documento() { Id = 6, Titulo = "Mandato de Busca", Tipo = "Mandato",
                          DataCriacao = new DateTime(2022, 06, 15), Status = "Pendente",
                          Observacoes = "Mandado de Busca aguardando assinatura do judiciário", Assinado = false, ParteId = 2 }
    };


        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Documento> lista = await _context.TB_DOCUMENTOS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetDocumento(int id)
        {
            try
            {
                Documento d = await _context.TB_DOCUMENTOS
                    .FirstOrDefaultAsync(dBusca => dBusca.Id == id);

                return Ok(d);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Add(Documento novoDocumento)
        {
            try
            {
                await _context.TB_DOCUMENTOS.AddAsync(novoDocumento);
                await _context.SaveChangesAsync();

                return Ok(novoDocumento.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public async Task<IActionResult> Update(Documento novoDocumento)
        {
            try
            {
                _context.TB_DOCUMENTOS.Update(novoDocumento);
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
                Documento dRemover = await _context.TB_DOCUMENTOS.FirstOrDefaultAsync(d => d.Id == id);

                _context.TB_DOCUMENTOS.Remove(dRemover);
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