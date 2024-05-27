using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDotnetExample.Application;
using WebApiDotnetExample.Model;

namespace WebApiDotnetExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaApplication _pessoaApplication;

        public PessoaController(PessoaApplication pessoaApplication)
        {
            _pessoaApplication = pessoaApplication;
        }

        // GET: api/Pessoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            var pessoas = await _pessoaApplication.GetPessoasAsync();
            return Ok(pessoas);
        }

        // GET: api/Pessoa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _pessoaApplication.GetPessoaAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            return Ok(pessoa);
        }

        // POST: api/Pessoa
        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa([FromBody] Pessoa pessoa)
        {
            var novaPessoa = await _pessoaApplication.AddPessoaAsync(pessoa);
            return CreatedAtAction(nameof(GetPessoa), new { id = novaPessoa.Id }, novaPessoa);
        }

        // PUT: api/Pessoa/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPessoa(int id, [FromBody] Pessoa pessoa)
        {
            var updated = await _pessoaApplication.UpdatePessoaAsync(id, pessoa);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Pessoa/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePessoa(int id)
        {
            var deleted = await _pessoaApplication.DeletePessoaAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
