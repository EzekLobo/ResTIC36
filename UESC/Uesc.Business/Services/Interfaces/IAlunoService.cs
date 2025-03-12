
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.Services;
public interface IAlunoService
{
    Task <List<AlunoViewModel>> ListarAlunos();
    Task <AlunoViewModel> BuscarAlunoPorId(int id);
    Task <AlunoViewModel> InserirAluno(AlunoInputModel aluno);
    Task <AlunoViewModel> AtualizarAluno(int id, UpdateAlunoInputModel aluno);
    Task <AlunoViewModel> RemoverAluno(int id);
    

    
}
