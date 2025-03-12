
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.IRepository;

public interface IMateriaRepository
{
    Task <List<MateriaViewModel>> ListarMaterias();
    Task <MateriaViewModel> BuscarMateriaPorId(int id);
    Task <MateriaViewModel> InserirMateria(MateriaInputModel Materia);
    Task <MateriaViewModel> AtualizarMateria(int id,UpdateMateriaInputModel Materia);
    Task <MateriaViewModel> RemoverMateria(int id);
    Task VerificarMateriaPorCodigo(int matricula);

}
