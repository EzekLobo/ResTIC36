using System;
using Uesc.Business.Entities;
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;
using Uesc.Business.IRepository;
using Uesc.Infra.DATA;

namespace Uesc.Infra.Repository;

public class MateriaRepository : IMateriaRepository
{
    private readonly UescDbContext _context;
    public MateriaRepository(UescDbContext context)
    {
        _context = context;
    }
    public MateriaViewModel AtualizarMateria(int id, UpdateMateriaInputModel Materia)
    {
        var materia = _context.Materias.FirstOrDefault(x => x.Id == id);
        if (materia == null)
        {
            throw new Exception("ID não encontrado");
        }
        materia.Nome = Materia.Nome;

        return new MateriaViewModel
        {
            Id = materia.Id,
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };
    }

    public MateriaViewModel BuscarMateriaPorId(int id)
    {
        var materia = _context.Materias.FirstOrDefault(x => x.Id == id);
        if (materia == null)
        {
            throw new Exception("ID não encontrado.");
        }
        return new MateriaViewModel
        {
            Id = materia.Id,
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };
    }

    public MateriaViewModel InserirMateria(MateriaInputModel Materia)
    {
        var materia = new Materia
        {
            Codigo = Materia.Codigo,
            Nome = Materia.Nome,
            CargaHoraria = Materia.CargaHoraria
        };
        _context.Materias.Add(materia);
        _context.SaveChanges();

        return new MateriaViewModel
        {
            Id = materia.Id,
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };
    }

    public List<MateriaViewModel> ListarMaterias()
    {
        var materias = _context.Materias.ToList();

    return materias
    .Select(m => new MateriaViewModel
        {   Id = m.Id,
            Codigo = m.Codigo,
            Nome = m.Nome,
            CargaHoraria = m.CargaHoraria,
        })
        .ToList();
        }

    public MateriaViewModel RemoverMateria(int id)
    {
        var materia = _context.Materias.FirstOrDefault(x => x.Id == id);
        if (materia == null)
        {
            throw new Exception("ID não encontrado");
        }
        _context.Materias.Remove(materia);
        _context.SaveChanges();

        return new MateriaViewModel
        {
            Id = materia.Id,
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };
    }

    public void VerificarMateriaPorCodigo(int codigo)
    {
        var materia = _context.Materias.FirstOrDefault(x => x.Codigo == codigo);
        if (materia != null)
        {
            throw new Exception("Já existe uma Matéria com esse código.");
        }
    }
}
