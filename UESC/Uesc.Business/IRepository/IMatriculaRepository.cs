using Uesc.Business.Entities;

namespace Uesc.Business.IRepository;

public interface IMatriculaRepository 
{
    Task<bool> Insert(int alunoId, int materiaId);
    Task<List<Materia>> GetById(int alunoId);

}
