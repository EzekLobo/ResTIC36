using Uesc.Business.Entities;
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

    public async Task<Materia> Update(int id, Materia materia)
    {
        var materiaAtualizada = await _context.Materias.FindAsync(id);
        if (materiaAtualizada == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        materiaAtualizada.Nome = materia.Nome;
        materiaAtualizada.CargaHoraria = materia.CargaHoraria;

        _context.Materias.Update(materiaAtualizada);
        await _context.SaveChangesAsync();

        return materiaAtualizada;
    }

    public async Task<Materia> GetById(int id)
    {
        var materia = await _context.Materias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (materia == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        return materia;
    }

    public async Task<Materia> Insert(Materia materia)
    {
        var novaMateria = new Materia
        {
            Codigo = materia.Codigo,
            Nome = materia.Nome,
            CargaHoraria = materia.CargaHoraria
        };

        await _context.Materias.AddAsync(novaMateria);
        await _context.SaveChangesAsync();

        return novaMateria;
    }

    public async Task<List<Materia>> GetAll()
    {
        var materias = await _context.Materias.AsNoTracking().ToListAsync();

        return materias;
    }

    public async Task<Materia> Delete(int id)
    {
        var materia = await _context.Materias.FindAsync(id);
        if (materia == null)
            throw new KeyNotFoundException("Matéria com o ID fornecido não encontrada.");

        _context.Materias.Remove(materia);
        await _context.SaveChangesAsync();

        return materia;
    }

    public async Task CheckByCode(int codigo)
    {
        var materia = await _context.Materias.AnyAsync(x => x.Codigo == codigo);
        if (materia)
            throw new ArgumentException("Já existe uma matéria com o código fornecido.");
    }
}
