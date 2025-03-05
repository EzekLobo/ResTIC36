namespace Uesc.Api.Controller;
using Uesc.Infra.DATA;
using Microsoft.AspNetCore.Mvc;
using Uesc.Business.Services;
using Microsoft.EntityFrameworkCore;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Api.DTOs.InputModel;
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
    public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAlunos()
    {
        //return Ok(_alunoService.ListarAlunos());
 
       return Ok(_alunoRepository.ListarAlunos());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlunoViewModel>> GetAluno(int id)
    {
        //return Ok(_alunoService.BuscarAlunoPorId(id));

        return Ok(_alunoRepository.BuscarAlunoPorId(id));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAluno(int id, [FromBody]  AlunoInputModel aluno)
    {
        return Ok( _alunoService.AtualizarAluno(id, aluno));
    }

    [HttpPost]
    public async Task<ActionResult<AlunoViewModel>> PostAluno([FromBody] AlunoInputModel aluno)
    {
        return Ok(_alunoService.InserirAluno(aluno));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAluno(int id)
    {
        return Ok(_alunoService.RemoverAluno(id));
    }
}