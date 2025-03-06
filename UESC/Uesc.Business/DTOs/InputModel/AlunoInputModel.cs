using System.ComponentModel.DataAnnotations;
namespace Uesc.Api.DTOs.InputModel;

public class AlunoInputModel
{
    [Required(ErrorMessage = "O campo matrícula é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "A matrícula deve ser um número positivo.")]
    public int Matricula { get; set; }

    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome{ get; set; }
}
