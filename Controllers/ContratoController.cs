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
    public class ContratoController : ControllerBase
    {
        private static List<Contrato> contratos = new List<Contrato>()
        {
            new Contrato() {Id = 1, Titulo = "Primeiro Contrato", DataInicio = new DateTime(2023, 10, 24), DataFim = new DateTime(2024, 10, 24),
            Status = "Ativo", Cliente = "ETEC", Prestador = "EscritórioX", Valor = 1300},
            new Contrato() {Id = 2, Titulo = "Segundo Contrato", DataInicio = new DateTime(2023, 07, 08), DataFim = new DateTime(2024, 07, 08),
            Status = "Desativado", Cliente = "Casa de Bolo", Prestador = "EscritórioY", Valor = 2500},
            new Contrato() {Id = 3, Titulo = "Terceiro Contrato", DataInicio = new DateTime(2023, 04, 20), DataFim = new DateTime(2024, 04, 20),
            Status = "Ativo", Cliente = "Mercadinho", Prestador = "EscritórioZ", Valor = 800}
        };

        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Contrato c = contratos[0];
            return Ok(c);
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(contratos);
        }

        [HttpGet("{id}")]
        public ActionResult<Contrato> GetContrato(int id)
        {
            var contrato = contratos.FirstOrDefault(c => c.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }
            return Ok(contrato);
        }

        [HttpPost]
        public ActionResult<Contrato> PostContrato([FromBody] Contrato contrato)
        {
            
            contrato.Id = contratos.Max(c => c.Id) + 1;  
            contratos.Add(contrato);

            return Ok(contratos);
        }

        [HttpPut("{id}")]
        public IActionResult PutContrato(int id, [FromBody] Contrato contratoAtualizado)
        {
            var contratoExistente = contratos.FirstOrDefault(c => c.Id == id);

            if (contratoExistente == null)
            {
                return NotFound();
            }

 
            contratoExistente.Titulo = contratoAtualizado.Titulo;
            contratoExistente.DataInicio = contratoAtualizado.DataInicio;
            contratoExistente.DataFim = contratoAtualizado.DataFim;
            contratoExistente.Status = contratoAtualizado.Status;
            contratoExistente.Cliente = contratoAtualizado.Cliente;
            contratoExistente.Prestador = contratoAtualizado.Prestador;
            contratoExistente.Valor = contratoAtualizado.Valor;

            
            return Ok(contratos);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContrato(int id)
        {
 
            var contrato = contratos.FirstOrDefault(c => c.Id == id);

            if (contrato == null)
            {
                return NotFound();  
            }

            contratos.Remove(contrato);

            return Ok(contratos);
        }











    }
}