using System.ComponentModel.DataAnnotations;
namespace Uesc.Business.DTOs.InputModel;

public class AlunoInputModel
{
    [Required(ErrorMessage = "O campo matrícula é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "A matrícula deve ser um número positivo e menor ou igual a 2.147.483.647.")]
    public int Matricula { get; set; }

    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome{ get; set; }
}
