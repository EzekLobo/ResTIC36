namespace Uesc.Api.Controller;
using Uesc.Infra.DATA;
using Microsoft.AspNetCore.Mvc;
using Uesc.Business.Services;
using Microsoft.EntityFrameworkCore;
using Uesc.Business.DTOs.ViewModel;
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.IRepository;


[ApiController]
[Route("api/[controller]")]
public class AlunoController : ControllerBase
{
    private readonly IAlunoService _alunoService;
    private readonly IAlunoRepository _alunoRepository;

    public AlunoController(IAlunoService alunoService, IAlunoRepository alunoRepository)
    {
        _alunoService = alunoService;
        _alunoRepository = alunoRepository;
    }
    

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAluno()
    {
        //return Ok(_alunoService.ListarAlunos());
  
       return Ok(await _alunoRepository.ListarAlunos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlunoViewModel>> GetAluno(int id)
    {
        //return Ok(_alunoService.BuscarAlunoPorId(id));

        return await _alunoRepository.BuscarAlunoPorId(id);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult <AlunoViewModel>> PutAluno(int id, [FromBody]  UpdateAlunoInputModel aluno)
    {
        return await _alunoService.AtualizarAluno(id, aluno);
    }

    [HttpPost]
    public async Task<ActionResult<AlunoViewModel>> PostAluno([FromBody] AlunoInputModel aluno)
    {
        return await _alunoService.InserirAluno(aluno);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AlunoViewModel>> DeleteAluno(int id)
    {
        return await _alunoService.RemoverAluno(id);
    }
}