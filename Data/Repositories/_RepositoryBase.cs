using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Team17.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Team17.Data.Context;

namespace Team17.Data.Repositories
{
    public partial class _RepositoryBase<TEntity> : IDisposable
                                                  , _IRepositoryBase<TEntity>
                                                    where TEntity : class
    {

        protected readonly IConfiguration m_Config;

        public _RepositoryBase(IConfiguration config)
        {
            m_Config = config;
        }

        public string PersonId { get; set; }

        protected DbContext m_Ctx { get; set; }
        public DbContext Ctx
        {
            get
            {
                if (m_Ctx == null)
                {
                    string connectionString = m_Config
                        .GetSection("AppSettings")
                        .GetValue<string>("SQLConnection");

                    DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder();
                    optionsBuilder
                        .UseSqlServer(connectionString, opt => opt.CommandTimeout(7200))
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                    m_Ctx = new CMContext(optionsBuilder.Options);
                }

                return m_Ctx;
            }
        }
        
        public void _Add(TEntity obj)
        {
            Ctx.Set<TEntity>().Add(obj);
            Ctx.SaveChanges();
        }

        public TEntity _GetById(int id)
        {
            return Ctx.Set<TEntity>().Find(id);
        }

        public TEntity _GetByGuidId(string id)
        {
            Guid guid = Guid.Parse(id);

            return Ctx.Set<TEntity>().Find(guid);
        }

        public IEnumerable<TEntity> _GetAll()
        {
            return Ctx.Set<TEntity>().ToList();
        }

        public void _Update(TEntity obj)
        {
            Ctx.Entry(obj).State = EntityState.Modified;
            Ctx.SaveChanges();
        }

        public void _Remove(TEntity obj)
        {
            Ctx.Set<TEntity>().Remove(obj);
            Ctx.SaveChanges();
        }

        public void Dispose()
        {
            // Check the Field, not the Property, avoiding create a new instance
            if (m_Ctx != null)
            {
                Ctx.Dispose();
            }
        }

    }

}
