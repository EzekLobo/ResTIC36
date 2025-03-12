
using Microsoft.EntityFrameworkCore;
using Uesc.Infra.DATA;
using Uesc.Business.DTOs.ViewModel;
using Uesc.Business.IRepository;
namespace Uesc.Infra.Repository;


public class MatriculaRepository : IMatriculaRepository
{
    private readonly UescDbContext _context;

    public MatriculaRepository(UescDbContext context)
    {
        _context = context;
    }

    public async Task<bool> MatricularAlunoEmMateria(int alunoId, int materiaId)
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

    public async Task<MatriculaViewModel> BuscarMateriasPorAluno(int alunoId)
    {
        var aluno = await _context.Alunos
            .Include(a => a.Materias) 
            .FirstOrDefaultAsync(a => a.Id == alunoId);

        if (aluno == null)
           throw new KeyNotFoundException("Aluno não encontrado."); 
            
        
        var materias = aluno.Materias.Select(m => new MateriaViewModel
        {
            Id = m.Id,
            Codigo = m.Codigo,
            Nome = m.Nome,
            CargaHoraria = m.CargaHoraria
        }).ToList();

        return new MatriculaViewModel
        {
            AlunoId = aluno.Id,
            AlunoMatricula = aluno.Matricula,
            AlunoNome = aluno.Nome,
            Materias = materias
        };

    }




}
