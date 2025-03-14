using Microsoft.EntityFrameworkCore;
using Uesc.Infra.DATA;
using Uesc.Business.Entities;
using Uesc.Business.IRepository;

namespace Uesc.Infra.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly UescDbContext _context;

    public AlunoRepository(UescDbContext context)
    {
        _context = context;
    }

    public async Task<Aluno?> Update(int id, Aluno aluno)
    {
        var alunoAtualizado = await _context.Alunos.FindAsync(id);

        if (alunoAtualizado == null)
            return null;

        alunoAtualizado.Nome = aluno.Nome;

        _context.Alunos.Update(alunoAtualizado);
        await _context.SaveChangesAsync();

        return alunoAtualizado;
    }

    public async Task<Aluno?> GetById(int id)
    {
        return await _context.Alunos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Aluno> Insert(Aluno aluno)
    {
        await _context.Alunos.AddAsync(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<List<Aluno>> GetAll()
    {
        return await _context.Alunos.AsNoTracking().ToListAsync();
    }

    public async Task<Aluno?> Delete(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno == null)
            return null;

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<bool> CheckByRegistration(int matricula)
    {
        return await _context.Alunos.AnyAsync(a => a.Matricula == matricula);
    }
}