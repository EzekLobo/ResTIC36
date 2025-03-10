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
    public ActionResult<AlunoViewModel> GetAlunos()
    {
        //return Ok(_alunoService.ListarAlunos());
 
       return Ok(_alunoRepository.ListarAlunos());
    }

    [HttpGet("{id}")]
    public ActionResult<AlunoViewModel> GetAluno(int id)
    {
        //return Ok(_alunoService.BuscarAlunoPorId(id));

        return Ok(_alunoRepository.BuscarAlunoPorId(id));
    }

    [HttpPut("{id}")]
    public ActionResult<AlunoViewModel> PutAluno(int id, [FromBody]  UpdateAlunoInputModel aluno)
    {
        return Ok(_alunoService.AtualizarAluno(id, aluno));
    }

    [HttpPost]
    public ActionResult<AlunoViewModel> PostAluno([FromBody] AlunoInputModel aluno)
    {
        return Ok(_alunoService.InserirAluno(aluno));
    }

    [HttpDelete("{id}")]
    public ActionResult<AlunoViewModel> DeleteAluno(int id)
    {
        return Ok(_alunoService.RemoverAluno(id));
    }
}