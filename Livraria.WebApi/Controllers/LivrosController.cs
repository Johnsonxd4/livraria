using System.Collections.Generic;
using Livraria.Dominio.nsLivro;
using Livraria.DTO.Livro;
using Livraria.Servicos.nsLivro;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LivrosController : Controller
    {
        private ILivroServico _livroServico;

        public LivrosController(ILivroServico livroServico)
        {
            _livroServico = livroServico;
        }


        [HttpGet]
        public IEnumerable<Livro> Get()
        {
            return _livroServico.ListarEmOrdemAlfabetica();
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var retorno = _livroServico.Consultar(id);
            if (retorno != null)
                return Ok(retorno);
            return NotFound();
        }


        [HttpPost]
        public IActionResult Post([FromBody]LivroDTO.Salvar livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _livroServico.Salvar(livro);
            return Ok();
        }


        [HttpPut]
        public IActionResult Put([FromBody]LivroDTO.Atualizar livroDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _livroServico.Atualizar(livroDto);
            return Ok();
            
        }


        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _livroServico.Apagar(id);
        }
    }
}
