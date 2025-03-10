namespace Uesc.Business.Services;
using Uesc.Api.DTOs.InputModel;
using Uesc.Api.DTOs.ViewModel;

public interface IAlunoService
{
    List<AlunoViewModel> ListarAlunos();
    AlunoViewModel BuscarAlunoPorId(int id);
    AlunoViewModel InserirAluno(AlunoInputModel aluno);
    AlunoViewModel AtualizarAluno(int id, UpdateAlunoInputModel aluno);
    AlunoViewModel RemoverAluno(int id);
    

    
}
