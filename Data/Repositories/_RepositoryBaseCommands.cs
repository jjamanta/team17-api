using Team17.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Team17.Domain.Entities;
using System.Linq;
using Team17.Library;

namespace Team17.Data.Repositories
{
    public partial class _RepositoryBase<TEntity> : IDisposable
                                                  , _IRepositoryBase<TEntity>
                                                    where TEntity : class
    {
        protected string m_Prefix = "";

        private string PrepareProc(string storedProcedure)
        {
            storedProcedure = m_Prefix + storedProcedure;

            if (!storedProcedure.Trim().ToLower().StartsWith("dbo."))
            {
                storedProcedure = "dbo." + storedProcedure.Trim();
            }

            return storedProcedure;
        }
        protected IEnumerable<TEntity> ExecuteList(string storedProcedure)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery<TEntity>(storedProcedure);
        }

        protected IEnumerable<T> ExecuteList<T>(string storedProcedure)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery<T>(storedProcedure);
        }

        protected IEnumerable<T> ExecuteList<T>(string storedProcedure, params object[] parameters)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery<T>(storedProcedure, parameters);
        }

        protected IEnumerable<TEntity> ExecuteList(string storedProcedure, params object[] parameters)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery<TEntity>(storedProcedure, parameters);
        }

        protected IEnumerable<dynamic> ExecuteListDynamic(string storedProcedure, params object[] parameters)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQueryDynamic(storedProcedure, parameters);
        }

        protected object ExecuteScalar(string storedProcedure)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery(storedProcedure);
        }

        protected object ExecuteScalar(string storedProcedure, params object[] parameters)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery(storedProcedure, parameters);
        }

        protected _ReturnProc ExecuteTuple(string storedProcedure)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery<_ReturnProc>(storedProcedure).FirstOrDefault<_ReturnProc>();
        }

        protected _ReturnProc ExecuteTuple(string storedProcedure, params object[] parameters)
        {
            storedProcedure = PrepareProc(storedProcedure);
            return Ctx.Database.SqlQuery<_ReturnProc>(storedProcedure, parameters).FirstOrDefault<_ReturnProc>();
        }

        public string Encrypt(string password, string email)
        {
            if (string.IsNullOrEmpty(password))
            {
                return string.Empty;
            }

            email = email.ToLower().Trim();
            string salt = email.Split('@')[0] + "$XptoTeam17#" + password.Trim();

            return Security.HashText(salt);
        }

        public string ReplaceFields(string text, string[] fields, string[] values)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                text = text.Replace(fields[i], values[i]);
            }

            return text;
        }

    }
}
