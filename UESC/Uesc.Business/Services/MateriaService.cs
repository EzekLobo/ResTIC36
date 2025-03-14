using System;
using Uesc.Business.Entities;
using Uesc.Business.IRepository;

namespace Uesc.Business.Services;

public class MateriaService : IMateriaService
{
    private readonly IMateriaRepository _materiaRepository;

    public MateriaService(IMateriaRepository materiaRepository)
    {
        _materiaRepository = materiaRepository;
    }

    public async Task<Materia?> Update(int id, Materia materia)
    {
        var materiaExistente = await _materiaRepository.GetById(id);
        if (materiaExistente == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        materiaExistente.Nome = materia.Nome;
        materiaExistente.CargaHoraria = materia.CargaHoraria;

        return await _materiaRepository.Update(id, materiaExistente);
    }

    public async Task<Materia?> GetById(int id)
    {
        var materia = await _materiaRepository.GetById(id);
        if (materia == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        return materia;
    }

    public async Task<Materia> Insert(Materia materia)
    {
        bool codigoExistente = await _materiaRepository.CheckByCode(materia.Codigo);
        if (codigoExistente)
            throw new ArgumentException("Já existe uma matéria com o código fornecido.");

        return await _materiaRepository.Insert(materia);
    }

    public async Task<List<Materia>> GetAll()
    {
        var materias = await _materiaRepository.GetAll();
        if (!materias.Any())
            throw new InvalidOperationException("Nenhuma matéria encontrada.");

        return materias;
    }

    public async Task<Materia?> Delete(int id)
    {
        var materia = await _materiaRepository.GetById(id);
        if (materia == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        return await _materiaRepository.Delete(id);
    }
}