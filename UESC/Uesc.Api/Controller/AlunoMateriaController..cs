using Microsoft.AspNetCore.Mvc;
using Uesc.Business.IRepository;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class MatriculaController : ControllerBase
{
    private readonly IMatriculaRepository _matriculaRepository;

    public MatriculaController(IMatriculaRepository matriculaRepository)
    {
        _matriculaRepository = matriculaRepository;
    }

   
    [HttpPost("matricular")]
    public async Task<IActionResult> MatricularAlunoEmMateria(int alunoId, int materiaId)
    {
        var sucesso = await _matriculaRepository.MatricularAlunoEmMateria(alunoId, materiaId);
        
        if (!sucesso)
            return BadRequest("Aluno ou matéria não encontrados, ou aluno já matriculado.");

        return Ok("Aluno matriculado com sucesso!");
    }

    
    [HttpGet("materias/{alunoId}")]
    public async Task<ActionResult<List<MatriculaViewModel>>> BuscarMateriasPorAluno(int alunoId)
    {
        var materias = await _matriculaRepository.BuscarMateriasPorAluno(alunoId);
        

        return Ok(materias);
    }
}
