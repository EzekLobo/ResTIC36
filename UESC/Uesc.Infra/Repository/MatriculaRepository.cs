
using Microsoft.EntityFrameworkCore;
using Uesc.Infra.DATA;
using Uesc.Business.Entities;
using Uesc.Business.IRepository;

namespace Uesc.Infra.Repository;

public class MatriculaRepository : IMatriculaRepository
{
    private readonly UescDbContext _context;

    public MatriculaRepository(UescDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Insert(int alunoId, int materiaId)
    {
        var aluno = await _context.Alunos
            .Include(a => a.Materias) 
            .FirstOrDefaultAsync(a => a.Id == alunoId);

        var materia = await _context.Materias.FindAsync(materiaId);

        if (aluno == null || materia == null)
            return false; 

        if (!aluno.Materias.Contains(materia)) 
        {
            aluno.Materias.Add(materia);
            await _context.SaveChangesAsync();
        }

        return true;
    }

    public async Task<List<Materia>> GetById(int alunoId)
{
    var materias = await _context.Materias
        .Where(m => m.Alunos.Any(a => a.Id == alunoId))
        .ToListAsync();

    if (!materias.Any())
        throw new KeyNotFoundException("O aluno não está matriculado em nenhuma matéria.");

    return materias;
}


}
