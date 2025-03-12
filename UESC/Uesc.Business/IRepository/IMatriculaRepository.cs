using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.IRepository;

public interface IMatriculaRepository
{
    Task<bool> MatricularAlunoEmMateria(int alunoId, int materiaId);
    Task<MatriculaViewModel> BuscarMateriasPorAluno(int alunoId);

}
