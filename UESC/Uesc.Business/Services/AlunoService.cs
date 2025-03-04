using Uesc.Api.DTOs.InputModel;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Business.IRepository;

namespace Uesc.Business.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoService(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public AlunoInputModel AtualizarAluno(AlunoInputModel aluno)
    {
        return _alunoRepository.AtualizarAluno(aluno);
    }

    public AlunoViewModel BuscarAlunoPorId(int id)
    {
        return _alunoRepository.BuscarAlunoPorId(id);
    }

    public AlunoInputModel InserirAluno(AlunoInputModel aluno)
    {
        return _alunoRepository.InserirAluno(aluno);
    }

    public List<AlunoViewModel> ListarAlunos()
    {
        return _alunoRepository.ListarAlunos();
    }

    public AlunoInputModel RemoverAluno(int id)
    {
        return _alunoRepository.RemoverAluno(id);
    }
}
