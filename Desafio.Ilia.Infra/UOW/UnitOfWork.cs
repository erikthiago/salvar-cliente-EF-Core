using Desafio.Ilia.Infra.Contexts;
using Desafio.Ilia.Infra.UOW.Base;

namespace Desafio.Ilia.Infra.UOW
{
    public class UnitOfWork : UnitOfWorkBase
    {
        public UnitOfWork(EntityContext entityContext) : base(entityContext)
        {
        }
    }
}
