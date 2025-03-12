using System;

namespace Uesc.Business.Entities;

public class Materia
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }

    public List<Aluno> Alunos { get; set; } = new();

}
