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
        
        var alunoExists = await _matriculaRepository.GetById(alunoId) != null;
        var materiaExists = await _matriculaRepository.GetById(materiaId) != null;

        if (!alunoExists || !materiaExists)
            return false;

       
        var materiasDoAluno = await _matriculaRepository.GetById(alunoId);
        if (materiasDoAluno.Any(m => m.Id == materiaId))
            return false;

       
        return await _matriculaRepository.Insert(alunoId, materiaId);
    }

    public async Task<List<Materia>> GetById(int alunoId)
    {
        var materias = await _matriculaRepository.GetById(alunoId);

        return materias;
    }
}