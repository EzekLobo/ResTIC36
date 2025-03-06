namespace Uesc.Business.Services;
using Uesc.Api.DTOs.InputModel;
using Uesc.Api.DTOs.ViewModel;

public interface IAlunoService
{
    List<AlunoViewModel> ListarAlunos();
    AlunoViewModel BuscarAlunoPorId(int id);
    AlunoInputModel InserirAluno(AlunoInputModel aluno);
    AlunoInputModel AtualizarAluno(int id, AlunoInputModel aluno);
    AlunoInputModel RemoverAluno(int id);
    

    
}
