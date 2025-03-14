namespace Uesc.Api.Controller;
using Microsoft.AspNetCore.Mvc;
using Uesc.Business.Services;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Api.DTOs.InputModel;
using Uesc.Business.IRepository;
using Uesc.Business.Entities;


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
    public async Task<ActionResult<IEnumerable<AlunoViewModel>>> GetAll()
    {
        //return Ok(_alunoService.ListarAlunos());

        var aluno = await _alunoRepository.GetAll();
        var alunoViewModel = aluno.Select(a => new AlunoViewModel
        {
            Id = a.Id,
            Nome = a.Nome,
            Matricula = a.Matricula
        });

        return Ok(alunoViewModel);

  
       
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AlunoViewModel>> GetById(int id)
    {
        //return Ok(_alunoService.BuscarAlunoPorId(id));

        var aluno = await _alunoRepository.GetById(id);
        var alunoViewModel = new AlunoViewModel
        {
            Id = aluno.Id,
            Nome = aluno.Nome,
            Matricula = aluno.Matricula
        };

        return Ok(aluno);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult <AlunoViewModel>> Update(int id, [FromBody]  UpdateAlunoInputModel aluno)
    {
        var alunoAtualizado = await _alunoService.Update(id, new Aluno
        {
            Nome = aluno.Nome,
        });

        var alunoViewModel = new AlunoViewModel
        {
            Id = alunoAtualizado.Id,
            Nome = alunoAtualizado.Nome,
            Matricula = alunoAtualizado.Matricula
        };
        return Ok(alunoViewModel);
    }

    [HttpPost]
    public async Task<ActionResult<AlunoViewModel>> Insert([FromBody] AlunoInputModel aluno)
    {
       
        var alunoInserido= await _alunoService.Insert( new Aluno
        {
            Nome = aluno.Nome,
            Matricula = aluno.Matricula
        });

        var alunoViewModel = new AlunoViewModel
        {
            Id = alunoInserido.Id,
            Nome = alunoInserido.Nome,
            Matricula = alunoInserido.Matricula
        };

        return Ok(alunoInserido);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<AlunoViewModel>> Delete(int id)
    {
        var alunoDeletado = await _alunoService.Delete(id);
        var alunoViewModel = new AlunoViewModel
        {
            Id = alunoDeletado.Id,
            Nome = alunoDeletado.Nome,
            Matricula = alunoDeletado.Matricula
        };
        return Ok(alunoViewModel);
    }
}