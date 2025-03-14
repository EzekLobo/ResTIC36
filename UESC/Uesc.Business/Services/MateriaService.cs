using System;
using Uesc.Business.Entities;
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
    public async Task<Materia> Update(int id, Materia materia)
    {
        try
        {   
            return await _materiaRepository.Update(id, materia);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao atualizar materia: {ex.Message}");
        }
    }

    public async Task<Materia> GetById(int id)
    {
       try
        {
            return await _materiaRepository.GetById(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao buscar materia: {ex.Message}");
        }
    }

    public async Task<Materia> Insert(Materia materia)
    {
        try
        {
           await  _materiaRepository.CheckByCode(materia.Codigo);
            return await _materiaRepository.Insert(materia);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao inserir materia: {ex.Message}");
        }
    }

    public async Task<List<Materia>> GetAll()
    {
        try
        {
            return await _materiaRepository.GetAll();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao listar materias: {ex.Message}");
        }
    }

    public async Task<Materia> Delete(int id)
    {
        try
        {
            return await _materiaRepository.Delete(id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro ao remover materia: {ex.Message}");
        }
    }
}
