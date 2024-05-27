using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDotnetExample.Infra.Data;
using WebApiDotnetExample.Model;

namespace WebApiDotnetExample.Application
{
    public class PessoaApplication
    {
        private readonly PessoaRepository _pessoaRepository;

        public PessoaApplication(PessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasAsync()
        {
            return await _pessoaRepository.GetPessoasAsync();
        }

        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            return await _pessoaRepository.GetPessoaAsync(id);
        }

        public async Task<Pessoa> AddPessoaAsync(Pessoa pessoa)
        {
            return await _pessoaRepository.AddPessoaAsync(pessoa);
        }

        public async Task<bool> UpdatePessoaAsync(int id, Pessoa pessoa)
        {
            pessoa.Id = id;
            return await _pessoaRepository.UpdatePessoaAsync(pessoa);
        }

        public async Task<bool> DeletePessoaAsync(int id)
        {
            return await _pessoaRepository.DeletePessoaAsync(id);
        }
    }
}
