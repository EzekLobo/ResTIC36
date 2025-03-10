using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.IRepository;

public interface IAlunoRepository
{
    List<AlunoViewModel> ListarAlunos();
    AlunoViewModel BuscarAlunoPorId(int id);
    AlunoViewModel InserirAluno(AlunoInputModel aluno);
    AlunoViewModel AtualizarAluno(int id,UpdateAlunoInputModel aluno);
    AlunoViewModel RemoverAluno(int id);
    void VerificarAlunoPorMatricula(int matricula);
}
