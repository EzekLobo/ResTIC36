using Uesc.Business.IRepository;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepository;

    public MatriculaService(IMatriculaRepository matriculaRepository)
    {
        _matriculaRepository = matriculaRepository;
    }

    public async Task<bool> MatricularAluno(int alunoId, int materiaId)
    {
        return await _matriculaRepository.MatricularAlunoEmMateria(alunoId, materiaId);
    }

    public async Task<MatriculaViewModel> ObterMateriasDoAluno(int alunoId)
    {
        return await _matriculaRepository.BuscarMateriasPorAluno(alunoId);
    }
}
