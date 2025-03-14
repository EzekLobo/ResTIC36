using System;
using Uesc.Business.Entities;

namespace Uesc.Business.Services;

public interface IMatriculaService
{
    Task<bool> Insert(int alunoId, int materiaId);
    Task<List<Materia>> GetById(int alunoId);

}
