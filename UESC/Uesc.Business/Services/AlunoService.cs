using System;
using Uesc.Business.Entities;
using Uesc.Business.IRepository;

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
        var alunoExistente = await _alunoRepository.GetById(id);
        if (alunoExistente == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");

        alunoExistente.Nome = aluno.Nome;

        var alunoAtualizado = await _alunoRepository.Update(id, alunoExistente);
        if (alunoAtualizado == null)
            throw new InvalidOperationException("Erro ao atualizar o aluno.");

        return alunoAtualizado;
    }

    public async Task<Aluno> GetById(int id)
    {
        var aluno = await _alunoRepository.GetById(id);
        if (aluno == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");

        return aluno;
    }

    public async Task<Aluno> Insert(Aluno aluno)
    {
        bool matriculaExistente = await _alunoRepository.CheckByRegistration(aluno.Matricula);
        if (matriculaExistente)
            throw new ArgumentException("Já existe um aluno com a matrícula fornecida.");

        return await _alunoRepository.Insert(aluno);
    }

    public async Task<List<Aluno>> GetAll()
    {
        var alunos = await _alunoRepository.GetAll();
        if (!alunos.Any())
            throw new InvalidOperationException("Nenhum aluno encontrado.");

        return alunos;
    }

    public async Task<Aluno> Delete(int id)
    {
        var aluno = await _alunoRepository.GetById(id);
        if (aluno == null)
            throw new KeyNotFoundException("Aluno com o ID fornecido não encontrado.");

        var alunoRemovido = await _alunoRepository.Delete(id);
        if (alunoRemovido == null)
            throw new InvalidOperationException("Erro ao remover o aluno.");

        return alunoRemovido;
    }
}