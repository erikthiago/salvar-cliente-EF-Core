using Desafio.Ilia.Domain.Base;
using Desafio.Ilia.Domain.Base.Interfaces;
using Desafio.Ilia.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Ilia.Infra.Repositories.Base
{
    public class BaseRepository<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : BaseEntity
        where TContext : EntityContext
    {
        public EntityContext _contextEntity;
        protected DbSet<TEntity> DbSet;

        public BaseRepository(EntityContext contextEntity)
        {
            _contextEntity = contextEntity;
            DbSet = contextEntity.Set<TEntity>();
        }

        /// <summary>
        /// Método que vai adicionar o novo dado ao contexto para ser inserido no banco de dados
        /// </summary>
        /// <param name="obj">Entidade preenchida corretamente</param>
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        /// <summary>
        /// Método que vai realizar a alteração do dado no contexto a ser persistido no banco de dados
        /// </summary>
        /// <param name="obj">Entidade preenchida corretamente</param>
        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        /// <summary>
        /// Método que faz a pesquisa no banco de dados utilizando um identificador específico.
        /// </summary>
        /// <param name="Id">Identificador do dado</param>
        /// <returns></returns>
        public virtual TEntity GetById(Guid Id)
        {
            return DbSet.Find(Id);
        }

        /// <summary>
        /// Método que faz a exclusão do registro desejado
        /// </summary>
        /// <param name="Id">Identificador do dado</param>
        public virtual void Remove(Guid Id)
        {
            DbSet.Remove(DbSet.Find(Id));
        }
        
        public virtual void Dispose()
        {
            _contextEntity.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
