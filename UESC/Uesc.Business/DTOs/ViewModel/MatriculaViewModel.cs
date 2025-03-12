


namespace Uesc.Business.DTOs.ViewModel;

public class MatriculaViewModel
{ 
    public int AlunoId { get; set; }
    public int AlunoMatricula { get; set; }
    public string AlunoNome  { get; set; } = string.Empty;
    public List<MateriaViewModel> Materias { get; set; } = new List<MateriaViewModel>();

}
