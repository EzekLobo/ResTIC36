using Microsoft.AspNetCore.Mvc;
using Uesc.Business.IRepository;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Business.Entities;

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

   
    [HttpPost]
    public async Task<IActionResult> Insert(int alunoId, int materiaId)
    {
        var sucesso = await _matriculaRepository.Insert(alunoId, materiaId);
        
        if (!sucesso)
            return BadRequest("Aluno ou matéria não encontrados, ou aluno já matriculado.");

        return Ok("Aluno matriculado com sucesso!");
    }

    
    [HttpGet("materias/{alunoId}")]
    public async Task<ActionResult<MateriaViewModel>> GetById(int alunoId)
    {
        var matricula = await _matriculaRepository.GetById(alunoId);
        
        var materiaViewModel = matricula.Select(m => new MateriaViewModel
        {
            Id = m.Id,
            Codigo = m.Codigo,
            Nome = m.Nome,
            CargaHoraria = m.CargaHoraria
        });

        return Ok(materiaViewModel);
        
    }
}
