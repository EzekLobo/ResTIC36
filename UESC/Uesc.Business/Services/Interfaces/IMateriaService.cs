using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.Services;

public interface IMateriaService
{
    MateriaViewModel InserirMateria(MateriaInputModel materia);
    MateriaViewModel AtualizarMateria(int id, UpdateMateriaInputModel materia);
    MateriaViewModel BuscarMateriaPorId(int id);
    MateriaViewModel RemoverMateria(int id);
    List<MateriaViewModel> ListarMaterias();

}
