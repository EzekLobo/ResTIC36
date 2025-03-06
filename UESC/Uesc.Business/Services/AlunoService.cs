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

    public AlunoInputModel AtualizarAluno(int id, AlunoInputModel aluno)
    {
       try
        {
            var alunoEncontrado = _alunoRepository.VerificarAlunoPorMatricula(aluno.Matricula);
            if (alunoEncontrado != null)
                throw new InvalidOperationException("Já existe um aluno com essa matrícula.");

            return _alunoRepository.AtualizarAluno(id, aluno);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar aluno.", ex);
        }
    }

    public AlunoViewModel BuscarAlunoPorId(int id)
    {
        try
        {
            var aluno = _alunoRepository.BuscarAlunoPorId(id);
            if (aluno == null)
                throw new KeyNotFoundException("Aluno não encontrado.");
            
            return aluno;
        }
        catch (Exception)
        {
            throw new Exception("Erro inesperado ao buscar aluno.");
        }
    }

    public AlunoInputModel InserirAluno(AlunoInputModel aluno)
    {
        try
        {
            var alunoEncontrado = _alunoRepository.VerificarAlunoPorMatricula(aluno.Matricula);
            if (alunoEncontrado != null)
                throw new InvalidOperationException("Já existe um aluno com essa matrícula.");

            return _alunoRepository.InserirAluno(aluno); 
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao inserir aluno.", ex);
        }
    }


    public List<AlunoViewModel> ListarAlunos()
    {
        try
        {
            return _alunoRepository.ListarAlunos();
        }
        catch (Exception)
        {
            throw new Exception("Erro inesperado ao listar alunos.");
        }
    }

    public AlunoInputModel RemoverAluno(int id)
    {
        try
        {
            var alunoRemovido = _alunoRepository.RemoverAluno(id);
            if (alunoRemovido == null)
                throw new KeyNotFoundException("Aluno não encontrado para remoção.");

            return alunoRemovido;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro inesperado ao remover o aluno." , ex);
        }
    }
}
