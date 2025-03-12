using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.Services;

public interface IMateriaService
{
    Task <MateriaViewModel> InserirMateria(MateriaInputModel materia);
    Task <MateriaViewModel> AtualizarMateria(int id, UpdateMateriaInputModel materia);
    Task <MateriaViewModel> BuscarMateriaPorId(int id);
    Task <MateriaViewModel> RemoverMateria(int id);
    Task <List<MateriaViewModel>> ListarMaterias();

}
