using Uesc.Business.Entities;
using Uesc.Business.Services;

namespace Uesc.Business.IRepository;

public interface IAlunoRepository : IBaseInterface<Aluno>
{
    Task CheckByRegistration(int matricula);
}
