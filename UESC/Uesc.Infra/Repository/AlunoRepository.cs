using Uesc.Business.IRepository;
using Uesc.Infra.DATA;
using Uesc.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Uesc.Infra.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly UescDbContext _context;

    public AlunoRepository(UescDbContext context)
    {
        _context = context;
    }

    public async Task<Aluno> Update(int id, Aluno aluno)
    {
        var alunoAtualizado = await _context.Alunos.FindAsync(id);

        if (alunoAtualizado == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");
        
        alunoAtualizado.Nome = aluno.Nome;
        
        _context.Alunos.Update(alunoAtualizado);
        await _context.SaveChangesAsync();

        return alunoAtualizado;
    }

    public async Task<Aluno> GetById(int id)
    {
        var aluno = await _context.Alunos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

        if (aluno == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");

        return  aluno;
    }

    public async Task<Aluno> Insert(Aluno aluno)
    {
       

        await _context.Alunos.AddAsync(aluno);
        await _context.SaveChangesAsync();

        return aluno;
    }

    public async Task<List<Aluno>> GetAll()
    {
        var alunos = await _context.Alunos.AsNoTracking().ToListAsync();
        return alunos;
    }

    public async Task<Aluno> Delete(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno == null)
             throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();
        

        return aluno;
    }

    public async Task CheckByRegistration(int matricula)
    { 
        var aluno = await _context.Alunos.AnyAsync(a => a.Matricula == matricula);
        if (aluno)
            throw new Exception("Já existe um aluno com a matrícula fornecida.");
    }
}
