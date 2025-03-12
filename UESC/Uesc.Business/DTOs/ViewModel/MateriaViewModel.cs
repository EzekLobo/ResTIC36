using System;

namespace Uesc.Business.DTOs.ViewModel;

public class MateriaViewModel
{
    public int Id { get; set; }
    public int Codigo { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
}
