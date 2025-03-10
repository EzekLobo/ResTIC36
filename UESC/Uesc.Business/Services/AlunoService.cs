using Uesc.Api.DTOs.InputModel;
using Uesc.Api.DTOs.ViewModel;
using Uesc.Business.IRepository;
using System;

namespace Uesc.Business.Services;

public class AlunoService : IAlunoService
{
    private readonly IAlunoRepository _alunoRepository;

    public AlunoService(IAlunoRepository alunoRepository)
    {
        _alunoRepository = alunoRepository;
    }

    public AlunoViewModel AtualizarAluno(int id, UpdateAlunoInputModel aluno)
    {
       try
        {
            return _alunoRepository.AtualizarAluno(id, aluno);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar aluno: {ex.Message}");
        }
    }

    public AlunoViewModel BuscarAlunoPorId(int id)
    {
        try
        {
            var aluno = _alunoRepository.BuscarAlunoPorId(id); 
            return aluno;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao buscar aluno: {ex.Message}");
        }
    }

    public AlunoViewModel InserirAluno(AlunoInputModel aluno)
    {
        try
        {
            _alunoRepository.VerificarAlunoPorMatricula(aluno.Matricula);
            return _alunoRepository.InserirAluno(aluno); 
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao inserir aluno: {ex.Message}");
        }
    }


    public List<AlunoViewModel> ListarAlunos()
    {
        try
        {
            return _alunoRepository.ListarAlunos();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao listar alunos:{ex.Message}");
        }
    }

    public AlunoViewModel RemoverAluno(int id)
    {
        try
        {
            return _alunoRepository.RemoverAluno(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao remover o aluno: {ex.Message}");
        }
    }
}
