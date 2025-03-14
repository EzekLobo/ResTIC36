using Microsoft.EntityFrameworkCore;
using Uesc.Infra.DATA;
using Uesc.Business.Entities;
using Uesc.Business.IRepository;

namespace Uesc.Infra.Repository;

public class MateriaRepository : IMateriaRepository
{
    private readonly UescDbContext _context;

    public MateriaRepository(UescDbContext context)
    {
        _context = context;
    }

    public async Task<Materia?> Update(int id, Materia materia)
    {
        var materiaAtualizada = await _context.Materias.FindAsync(id);
        if (materiaAtualizada == null)
            return null;

        materiaAtualizada.Nome = materia.Nome;
        materiaAtualizada.CargaHoraria = materia.CargaHoraria;

        _context.Materias.Update(materiaAtualizada);
        await _context.SaveChangesAsync();

        return materiaAtualizada;
    }

    public async Task<Materia?> GetById(int id)
    {
        return await _context.Materias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Materia> Insert(Materia materia)
    {
        await _context.Materias.AddAsync(materia);
        await _context.SaveChangesAsync();

        return materia;
    }

    public async Task<List<Materia>> GetAll()
    {
        return await _context.Materias.AsNoTracking().ToListAsync();
    }

    public async Task<Materia?> Delete(int id)
    {
        var materia = await _context.Materias.FindAsync(id);
        if (materia == null)
            return null;

        _context.Materias.Remove(materia);
        await _context.SaveChangesAsync();

        return materia;
    }

    public async Task<bool> CheckByCode(int codigo)
    {
        return await _context.Materias.AnyAsync(x => x.Codigo == codigo);
    }
}