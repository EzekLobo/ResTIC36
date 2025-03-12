using Uesc.Business.Entities;
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;
using Uesc.Business.IRepository;
using Uesc.Infra.DATA;
using Microsoft.EntityFrameworkCore;

namespace Uesc.Infra.Repository;

public class MateriaRepository : IMateriaRepository
{
    private readonly UescDbContext _context;

    public MateriaRepository(UescDbContext context)
    {
        _context = context;
    }

    public async Task<MateriaViewModel> AtualizarMateria(int id, UpdateMateriaInputModel materia)
    {
        var materiaAtualizada = await _context.Materias.FindAsync(id);
        if (materiaAtualizada == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        materiaAtualizada.Nome = materia.Nome;
        materiaAtualizada.CargaHoraria = materia.CargaHoraria;

        _context.Materias.Update(materiaAtualizada);
        await _context.SaveChangesAsync();

        return new MateriaViewModel
        {
            Id = materiaAtualizada.Id,
            Codigo = materiaAtualizada.Codigo,
            Nome = materiaAtualizada.Nome,
            CargaHoraria = materiaAtualizada.CargaHoraria
        };
    }

    public async Task<MateriaViewModel> BuscarMateriaPorId(int id)
    {
        var materia = await _context.Materias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (materia == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        return new MateriaViewModel
        {
            Id = materia.Id,
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };
    }

    public async Task<MateriaViewModel> InserirMateria(MateriaInputModel materia)
    {
        var novaMateria = new Materia
        {
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };

        await _context.Materias.AddAsync(novaMateria);
        await _context.SaveChangesAsync();

        return new MateriaViewModel
        {
            Id = novaMateria.Id,
            Codigo = novaMateria.Codigo,
            Nome = novaMateria.Nome,
            CargaHoraria = novaMateria.CargaHoraria
        };
    }

    public async Task<List<MateriaViewModel>> ListarMaterias()
    {
        var materias = await _context.Materias.AsNoTracking().ToListAsync();

        return materias.Select(m => new MateriaViewModel
        {
            Id = m.Id,
            Codigo = m.Codigo,
            Nome = m.Nome,
            CargaHoraria = m.CargaHoraria
        }).ToList();
    }

    public async Task<MateriaViewModel> RemoverMateria(int id)
    {
        var materia = await _context.Materias.FindAsync(id);
        if (materia == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        _context.Materias.Remove(materia);
        await _context.SaveChangesAsync();

        return new MateriaViewModel
        {
            Id = materia.Id,
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };
    }

    public async Task VerificarMateriaPorCodigo(int codigo)
    {
        var materia = await _context.Materias.AnyAsync(x => x.Codigo == codigo);
        if (materia)
            throw new ArgumentException("Já existe uma matéria com o código fornecido.");
    }
}
