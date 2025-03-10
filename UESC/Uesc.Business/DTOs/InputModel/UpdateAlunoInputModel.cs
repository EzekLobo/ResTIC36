using System.ComponentModel.DataAnnotations;
namespace Uesc.Api.DTOs.InputModel;

public class UpdateAlunoInputModel
{
    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome{ get; set; }
}
