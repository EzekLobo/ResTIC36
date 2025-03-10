
using Uesc.Business.DTOs.InputModel;
using Uesc.Business.DTOs.ViewModel;

namespace Uesc.Business.IRepository;

public interface IMateriaRepository
{
    List<MateriaViewModel> ListarMaterias();
    MateriaViewModel BuscarMateriaPorId(int id);
    MateriaViewModel InserirMateria(MateriaInputModel Materia);
    MateriaViewModel AtualizarMateria(int id,UpdateMateriaInputModel Materia);
    MateriaViewModel RemoverMateria(int id);
    void VerificarMateriaPorCodigo(int matricula);


}
