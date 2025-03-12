using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;
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

    public async Task<AlunoViewModel> AtualizarAluno(int id, UpdateAlunoInputModel aluno)
    {
       try
        {
            return await _alunoRepository.AtualizarAluno(id, aluno);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar aluno: {ex.Message}");
        }
    }

    public async Task<AlunoViewModel> BuscarAlunoPorId(int id)
    {
        try
        {
            var aluno = await _alunoRepository.BuscarAlunoPorId(id); 
            return aluno;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao buscar aluno: {ex.Message}");
        }
    }

    public async Task<AlunoViewModel> InserirAluno(AlunoInputModel aluno)
    {
        try
        {
           await  _alunoRepository.VerificarAlunoPorMatricula(aluno.Matricula);
            return await _alunoRepository.InserirAluno(aluno); 
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao inserir aluno: {ex.Message}");
        }
    }


    public async Task<List<AlunoViewModel>> ListarAlunos()
    {
        try
        {
            return await _alunoRepository.ListarAlunos();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao listar alunos:{ex.Message}");
        }
    }

    public async Task<AlunoViewModel> RemoverAluno(int id)
    {
        try
        {
            return await _alunoRepository.RemoverAluno(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao remover o aluno: {ex.Message}");
        }
    }
}
