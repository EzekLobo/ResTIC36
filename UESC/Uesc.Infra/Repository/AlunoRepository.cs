
using Uesc.Api.DTOs.InputModel;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Business.IRepository;
using Uesc.Infra.DATA;
using Uesc.Business.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Uesc.Infra.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly UescDbContext _context;

    public AlunoRepository(UescDbContext context)
    {
        _context = context;
    }
    public AlunoViewModel AtualizarAluno(int id, UpdateAlunoInputModel aluno)
    {
        var alunoAtualizado = _context.Alunos.FirstOrDefault(a => a.Id == id);

        if (alunoAtualizado == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");
        
        alunoAtualizado.Nome = aluno.Nome;
        
        _context.Alunos.Update(alunoAtualizado);
        _context.SaveChanges();

        var alunoViewModel = new AlunoViewModel
        {
            Id = alunoAtualizado.Id,
            Matricula = alunoAtualizado.Matricula,
            Nome = alunoAtualizado.Nome,
        };

        return alunoViewModel;
    }


    public AlunoViewModel BuscarAlunoPorId(int id)
    {
       var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

    if (aluno == null)
        throw new KeyNotFoundException("ID não encontrado"); 

    var alunoEncontrado = new AlunoViewModel
    {
        Id = aluno.Id,
        Matricula = aluno.Matricula,
        Nome = aluno.Nome,
    };

    return alunoEncontrado; 
        
    }

    public AlunoViewModel InserirAluno(AlunoInputModel aluno)
    {
        var novoAluno = new Aluno
        {
            Matricula = aluno.Matricula,
            Nome = aluno.Nome,
        };

        _context.Alunos.Add(novoAluno);
        _context.SaveChanges();


        return new AlunoViewModel
        {
            Id = novoAluno.Id,
            Matricula = novoAluno.Matricula,
            Nome = novoAluno.Nome,
        };
    }

    public List<AlunoViewModel> ListarAlunos()
    {
        var alunos = _context.Alunos.ToList();

    return alunos 
        .Select(a => new AlunoViewModel
        {   Id = a.Id,
            Matricula = a.Matricula,
            Nome = a.Nome,
        })
        .ToList();

    }

    public AlunoViewModel RemoverAluno(int id)
    {
        var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

    if (aluno == null)
        throw new KeyNotFoundException("ID não encontrada");
    
     var alunoRemovido = new AlunoViewModel
    {
        Id = aluno.Id,
        Matricula = aluno.Matricula,
        Nome = aluno.Nome,
    };
    _context.Alunos.Remove(aluno);
    _context.SaveChanges();

    return alunoRemovido;
    }

    public void VerificarAlunoPorMatricula(int matricula)
    {
        if (_context.Alunos.Any(a => a.Matricula == matricula))
             throw new InvalidOperationException("Já existe um aluno com essa matrícula."); 
    }

}
