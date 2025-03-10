using System;
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;
using Uesc.Business.Services;
using Uesc.Business.IRepository;

namespace Uesc.Business.Services;

public class MateriaService : IMateriaService
{
    private readonly IMateriaRepository _materiaRepository;

    public MateriaService(IMateriaRepository materiaRepository)
    {
        _materiaRepository = materiaRepository;
    }
    public MateriaViewModel AtualizarMateria(int id, UpdateMateriaInputModel materia)
    {
        try
        {   
            return _materiaRepository.AtualizarMateria(id, materia);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar materia: {ex.Message}");
        }
    }

    public MateriaViewModel BuscarMateriaPorId(int id)
    {
       try
        {
            return _materiaRepository.BuscarMateriaPorId(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar materia: {ex.Message}");
        }
    }

    public MateriaViewModel InserirMateria(MateriaInputModel materia)
    {
        try
        {
            _materiaRepository.VerificarMateriaPorCodigo(materia.Codigo);
            return _materiaRepository.InserirMateria(materia);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao inserir materia: {ex.Message}");
        }
    }

    public List<MateriaViewModel> ListarMaterias()
    {
        try
        {
            return _materiaRepository.ListarMaterias();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar materias: {ex.Message}");
        }
    }

    public MateriaViewModel RemoverMateria(int id)
    {
        try
        {
            return _materiaRepository.RemoverMateria(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao remover materia: {ex.Message}");
        }
    }
}
