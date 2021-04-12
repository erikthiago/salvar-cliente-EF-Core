using System;

namespace Desafio.Ilia.Domain.Base.Interfaces
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid Id);
        void Update(TEntity obj);
        void Remove(Guid Id);
    }
}
