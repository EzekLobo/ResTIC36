using System;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.Services;

public interface IMatriculaService
{
    Task<bool> MatricularAluno(int alunoId, int materiaId);
    Task<MatriculaViewModel> ObterMateriasDoAluno(int alunoId);

}
