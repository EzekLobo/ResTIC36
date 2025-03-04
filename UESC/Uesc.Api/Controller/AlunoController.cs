namespace Uesc.Api.Controller;
using Uesc.Infra.DATA;
using Microsoft.AspNetCore.Mvc;
using Uesc.Business.Entities;
using Uesc.Business.Services;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Api.DTOs.InputModel;

[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos()
    {
        var alunos = await Task.Run(() => _alunoService.ListarAlunos());
        return Ok(alunos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlunoViewModel>> GetAluno(int matricula)
    {
        var aluno = await Task.Run(() => _alunoService.BuscarAlunoPorId(matricula));
        if (aluno == null)
            return NotFound("Aluno não encontrado");

        return Ok(aluno);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAluno(int matricula, [FromBody] AlunoInputModel aluno)
    {
        if (matricula != aluno.Matricula)
            return BadRequest("Matrícula inconsistente");

        await Task.Run(() => _alunoService.AtualizarAluno(aluno));
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<AlunoViewModel>> PostAluno([FromBody] AlunoInputModel aluno)
    {
        var novoAluno = await Task.Run(() => _alunoService.InserirAluno(aluno));
        return CreatedAtAction(nameof(GetAluno), new { matricula = novoAluno.Matricula }, novoAluno);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAluno(int matricula)
    {
        var alunoRemovido = await Task.Run(() => _alunoService.RemoverAluno(matricula));
        if (alunoRemovido == null)
            return NotFound("Aluno não encontrado");

        return Ok(alunoRemovido);
    }
}