using System.Collections.Generic;

namespace Team17.Domain.Interfaces.Repositories
{
    public interface _IRepositoryBase<TEntity> where TEntity : class
    {
        string PersonId { get; set; }

        void _Add(TEntity obj);
        TEntity _GetById(int id);
        TEntity _GetByGuidId(string id);
        IEnumerable<TEntity> _GetAll();
        void _Update(TEntity obj);
        void _Remove(TEntity obj);
        void Dispose();
    }

}
