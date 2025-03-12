using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;
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

    public async Task<AlunoViewModel> AtualizarAluno(int id, UpdateAlunoInputModel aluno)
    {
        var alunoAtualizado = await _context.Alunos.FindAsync(id);

        if (alunoAtualizado == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");
        
        alunoAtualizado.Nome = aluno.Nome;
        
        _context.Alunos.Update(alunoAtualizado);
        await _context.SaveChangesAsync();

        return new AlunoViewModel
        {
            Id = alunoAtualizado.Id,
            Matricula = alunoAtualizado.Matricula,
            Nome = alunoAtualizado.Nome
        };
    }

    public async Task<AlunoViewModel> BuscarAlunoPorId(int id)
    {
        var aluno = await _context.Alunos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

        if (aluno == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");

        return  new AlunoViewModel
        {
            Id = aluno.Id,
            Matricula = aluno.Matricula,
            Nome = aluno.Nome
        };
    }

    public async Task<AlunoViewModel> InserirAluno(AlunoInputModel aluno)
    {
        var novoAluno = new Aluno
        {
            Matricula = aluno.Matricula,
            Nome = aluno.Nome
        };

        await _context.Alunos.AddAsync(novoAluno);
        await _context.SaveChangesAsync();

        return new AlunoViewModel
        {
            Id = novoAluno.Id,
            Matricula = novoAluno.Matricula,
            Nome = novoAluno.Nome
        };
    }

    public async Task<List<AlunoViewModel>> ListarAlunos()
    {
        var alunos = await _context.Alunos.AsNoTracking().ToListAsync();
        return alunos.Select(a => new AlunoViewModel
        {
            Id = a.Id,
            Matricula = a.Matricula,
            Nome = a.Nome
        }).ToList();
    }

    public async Task<AlunoViewModel> RemoverAluno(int id)
    {
        var aluno = await _context.Alunos.FindAsync(id);

        if (aluno == null)
             throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");

        _context.Alunos.Remove(aluno);
        await _context.SaveChangesAsync();

        return new AlunoViewModel
        {
            Id = aluno.Id,
            Matricula = aluno.Matricula,
            Nome = aluno.Nome
        };
    }

    public async Task VerificarAlunoPorMatricula(int matricula)
    { 
        var aluno = await _context.Alunos.AnyAsync(a => a.Matricula == matricula);
        if (aluno)
            throw new Exception("Já existe um aluno com a matrícula fornecida.");
    }
}
