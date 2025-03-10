
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.Services;
public interface IAlunoService
{
    List<AlunoViewModel> ListarAlunos();
    AlunoViewModel BuscarAlunoPorId(int id);
    AlunoViewModel InserirAluno(AlunoInputModel aluno);
    AlunoViewModel AtualizarAluno(int id, UpdateAlunoInputModel aluno);
    AlunoViewModel RemoverAluno(int id);
    

    
}
