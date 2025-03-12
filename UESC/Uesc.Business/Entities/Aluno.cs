using System.ComponentModel.DataAnnotations;

namespace Uesc.Business.Entities;

public class Aluno
{
    public int Id { get; set;}
    public int Matricula { get; set;}
    public string Nome { get; set;} = string.Empty;

    public List<Materia> Materias { get; set; } = new();
    
}
