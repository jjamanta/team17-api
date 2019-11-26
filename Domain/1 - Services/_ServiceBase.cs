using System;
using System.Collections.Generic;
using Team17.Domain.Interfaces.Repositories;
using Team17.Domain.Interfaces.Services;

namespace Team17.Domain.Services
{
    public class _ServiceBase<TEntity> : IDisposable, _IServiceBase<TEntity> where TEntity : class
    {
        private readonly _IRepositoryBase<TEntity> m_Repository;
        public string PersonId { get; set; }

        public _ServiceBase(_IRepositoryBase<TEntity> repository)
        {
            m_Repository = repository;
        }

        public void _Add(TEntity obj)
        {
            m_Repository._Add(obj);
        }

        public TEntity _GetById(int id)
        {
            return m_Repository._GetById(id);
        }

        public TEntity _GetByGuidId(string id)
        {
            return m_Repository._GetByGuidId(id);
        }
        public IEnumerable<TEntity> _GetAll()
        {
            return m_Repository._GetAll();
        }

        public void _Update(TEntity obj)
        {
            m_Repository._Update(obj);
        }

        public void _Remove(TEntity obj)
        {
            m_Repository._Remove(obj);
        }

        public void Dispose()
        {
            m_Repository.Dispose();
        }

    }
}
