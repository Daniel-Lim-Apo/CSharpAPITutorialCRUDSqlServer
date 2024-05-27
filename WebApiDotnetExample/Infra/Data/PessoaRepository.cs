using Microsoft.EntityFrameworkCore;
using WebApiDotnetExample.Model;

namespace WebApiDotnetExample.Infra.Data
{
    public class PessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasAsync()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            return await _context.Pessoas.FindAsync(id);
        }

        public async Task<Pessoa> AddPessoaAsync(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<bool> UpdatePessoaAsync(Pessoa pessoa)
        {
            var existingPessoa = await _context.Pessoas.FindAsync(pessoa.Id);
            if (existingPessoa == null)
            {
                return false;
            }

            existingPessoa.Nome = pessoa.Nome;
            existingPessoa.CPF = pessoa.CPF;
            existingPessoa.Email = pessoa.Email;
            existingPessoa.DataDeNascimento = pessoa.DataDeNascimento;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePessoaAsync(int id)
        {
            var pessoa = await _context.Pessoas.FindAsync(id);
            if (pessoa == null)
            {
                return false;
            }

            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
