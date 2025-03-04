
using Uesc.Api.DTOs.InputModel;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Business.IRepository;
using Uesc.Infra.DATA;
using Uesc.Business.Entities;

namespace Uesc.Infra.Repository;

public class AlunoRepository : IAlunoRepository
{
    private readonly UescDbContext _context;

    public AlunoRepository(UescDbContext context)
    {
        _context = context;
    }
    public AlunoInputModel AtualizarAluno(AlunoInputModel aluno)
    {   
        var alunoAtualizado = _context.Alunos.FirstOrDefault(a => a.Matricula == aluno.Matricula);

    if (alunoAtualizado == null)
    {
        throw new KeyNotFoundException("Matricula não encontrada");
    }

    alunoAtualizado.Nome = aluno.Nome;
 
    _context.Alunos.Update(alunoAtualizado);
    _context.SaveChanges();

    return aluno;
    }

    public AlunoViewModel BuscarAlunoPorId(int matricula)
    {
       var aluno = _context.Alunos.FirstOrDefault(a => a.Matricula == matricula);

    if (aluno == null)
    {
        throw new KeyNotFoundException("Matricula não encontrada"); 
    }

    var alunoEncontrado = new AlunoViewModel
    {
        Matricula = aluno.Matricula,
        Nome = aluno.Nome,
    };

    return alunoEncontrado; 
        
    }

    public AlunoInputModel InserirAluno(AlunoInputModel aluno)
    {
        var novoAluno = new Aluno
        {
            Matricula = aluno.Matricula,
            Nome = aluno.Nome,
        };

        _context.Alunos.Add(novoAluno);
        _context.SaveChanges();
        return aluno;
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

    public AlunoInputModel RemoverAluno(int id)
    {
        var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

    if (aluno == null)
        throw new KeyNotFoundException("Matricula não encontrada");
    
     var alunoRemovido = new AlunoInputModel
    {
        Matricula = aluno.Matricula,
        Nome = aluno.Nome,
    };
    _context.Alunos.Remove(aluno);
    _context.SaveChanges();

    return alunoRemovido;
    }

}
