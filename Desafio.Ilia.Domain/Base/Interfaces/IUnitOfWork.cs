using System;

namespace Desafio.Ilia.Domain.Base.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
