using Uesc.Business.Entities;
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

    public async Task<Aluno> Update(int id, Aluno aluno)
    {
       try
        {
            return await _alunoRepository.Update(id, aluno);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar aluno: {ex.Message}");
        }
    }

    public async Task<Aluno> GetById(int id)
    {
        try
        {
            var aluno = await _alunoRepository.GetById(id); 
            
            return aluno;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao buscar aluno: {ex.Message}");
        }
    }

    public async Task<Aluno> Insert(Aluno aluno)
    {
        try
        {
           await  _alunoRepository.CheckByRegistration(aluno.Matricula);
            return await _alunoRepository.Insert(aluno); 
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao inserir aluno: {ex.Message}");
        }
    }


    public async Task<List<Aluno>> GetAll()
    {
        try
        {
            return await _alunoRepository.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao listar alunos:{ex.Message}");
        }
    }

    public async Task<Aluno> Delete(int id)
    {
        try
        {
            return await _alunoRepository.Delete(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro inesperado ao remover o aluno: {ex.Message}");
        }
    }
}
