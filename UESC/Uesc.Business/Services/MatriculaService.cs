using Uesc.Business.IRepository;
using Uesc.Business.Entities;

namespace Uesc.Business.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepository;

    public MatriculaService(IMatriculaRepository matriculaRepository)
    {
        _matriculaRepository = matriculaRepository;
    }

    public async Task<bool> Insert(int alunoId, int materiaId)
    {
        return await _matriculaRepository.Insert(alunoId, materiaId);
    }

    public async Task<List<Materia>> GetById(int alunoId)
    {
        return await _matriculaRepository.GetById(alunoId);
    }
}
