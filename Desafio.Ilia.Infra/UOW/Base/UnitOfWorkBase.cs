using Desafio.Ilia.Domain.Base.Interfaces;
using Desafio.Ilia.Infra.Contexts.Base;
using System;

namespace Desafio.Ilia.Infra.UOW.Base
{
    public class UnitOfWorkBase : IUnitOfWork
    {
        // Informa o contexto
        private readonly EntityContextBase _context;

        // O contexto é passado pelo construtor
        public UnitOfWorkBase(EntityContextBase context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que vai salvar, editar ou excluir o dado informado no contexto
        /// </summary>
        /// <returns>Retorna a quantidade de linhas afetadas pela operação</returns>
        public bool Commit()
        {
            try
            {
                var rowsAffected = _context.SaveChanges();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
