using System;
using System.ComponentModel.DataAnnotations;

namespace Uesc.Business.DTOs.InputModel;

public class UpdateMateriaInputModel
{
    [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }

}
