using Uesc.Business.Entities;
using Uesc.Business.Services;

namespace Uesc.Business.IRepository;

public interface IMateriaRepository : IBaseInterface<Materia>
{
    Task<bool> CheckByCode(int matricula);

}
