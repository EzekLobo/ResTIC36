using Uesc.Business.Entities;
using Uesc.Business.Services;

namespace Uesc.Business.IRepository;

public interface IMateriaRepository : IBaseInterface<Materia>
{
    Task CheckByCode(int matricula);

}
