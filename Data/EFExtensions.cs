using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Microsoft.EntityFrameworkCore
{
    public static class EFExtensions
    {
        public static IEnumerable<TEntity> SqlQuery<TEntity>(this DatabaseFacade databaseFacade, string storedProcName)
        {
            var rawSqlCommand = databaseFacade
                .GetService<IRawSqlCommandBuilder>()
                .Build(storedProcName);

            return MapToList<TEntity>(
                     rawSqlCommand
                    .ExecuteReader(
                        databaseFacade.GetService<IRelationalConnection>()));
        }

        private static string PrepareParams(string storedProcedure, ref object[] parameters)
        {
            string procWithParams = storedProcedure;
            string comma = "";

            // Exclude null dates from array, passed as reference due this change
            parameters = parameters.Except(new object[] { DateTime.MinValue }).ToArray();

            foreach (object obj in parameters)
            {
                if (((SqlParameter)obj).Value is DateTime && ((SqlParameter)obj).Value.Equals(DateTime.MinValue))
                {
                    // Exclude null dates from array, passed as reference due this change
                    parameters = parameters.Except(new object[] { obj }).ToArray();
                    continue;
                }

                string strValue = "";
                if (((SqlParameter)obj).Value != null)
                {
                    strValue = ((SqlParameter)obj).Value.ToString();
                }

                if (((SqlParameter)obj).ParameterName.EndsWith("Id") && strValue.Equals(""))
                {
                    continue;
                }

                procWithParams += String.Format(" {0}@{1}='{2}'", comma, ((SqlParameter)obj).ParameterName, strValue);
                comma = ",";
            }

            return procWithParams;
        }

        public static IEnumerable<TEntity> SqlQuery<TEntity>(this DatabaseFacade databaseFacade, string storedProcName, params object[] parameters)
        {
            storedProcName = PrepareParams(storedProcName, ref parameters);

            var rawSqlCommand = databaseFacade
                .GetService<IRawSqlCommandBuilder>()
                .Build(storedProcName);

            return MapToList<TEntity>(
                     rawSqlCommand
                    .ExecuteReader(
                        databaseFacade.GetService<IRelationalConnection>()));
        }

        public static IEnumerable<dynamic> SqlQueryDynamic(this DatabaseFacade databaseFacade
            , string storedProcName
            , params object[] parameters)
        {
            storedProcName = PrepareParams(storedProcName, ref parameters);

            var rawSqlCommand = databaseFacade
                .GetService<IRawSqlCommandBuilder>()
                .Build(storedProcName);

            RelationalDataReader reader = rawSqlCommand.ExecuteReader(databaseFacade.GetService<IRelationalConnection>());

            return MapToList(reader.DbDataReader);
        }

        public static object SqlQuery(this DatabaseFacade databaseFacade, string storedProcName, params object[] parameters)
        {
            storedProcName = PrepareParams(storedProcName, ref parameters);

            var rawSqlCommand = databaseFacade
                    .GetService<IRawSqlCommandBuilder>()
                    .Build(storedProcName);

            return rawSqlCommand
                    .ExecuteScalar(
                        databaseFacade.GetService<IRelationalConnection>());
        }

        public static object SqlQuery(this DatabaseFacade databaseFacade, string storedProcName)
        {
            var rawSqlCommand = databaseFacade
                .GetService<IRawSqlCommandBuilder>()
                .Build(storedProcName);

            return rawSqlCommand
                    .ExecuteScalar(
                        databaseFacade.GetService<IRelationalConnection>());
        }

        private static IEnumerable<TEntity> MapToList<TEntity>(RelationalDataReader reader)
        {
            DbDataReader dr = reader.DbDataReader;
            var objList = new List<TEntity>();
            var props = typeof(TEntity).GetRuntimeProperties().ToList();

            var colMapping = dr.GetColumnSchema()
                .Where(x => props.Any(y => y.Name.ToLower() == x.ColumnName.ToLower()))
                .ToDictionary(key => key.ColumnName.ToLower());

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    TEntity obj = Activator.CreateInstance<TEntity>();
                    foreach (var prop in props)
                    {
                        if (colMapping.ContainsKey(prop.Name.ToLower()))
                        {
                            var column = colMapping[prop.Name.ToLower()];

                            if (column?.ColumnOrdinal != null)
                            {
                                object val = dr.GetValue(column.ColumnOrdinal.Value);
                                prop.SetValue(obj, val == DBNull.Value ? null : ((val is Guid) ? val.ToString() : val));
                            }
                        }
                    }
                    objList.Add(obj);
                }
            }
            dr.Close();
            return objList.AsEnumerable<TEntity>();
        }

        private static IEnumerable<dynamic> MapToList(DbDataReader dr)
        {
            var objList = new List<dynamic>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dynamic obj = new ExpandoObject();
                    var dictionary = (IDictionary<string, object>)obj;                             
                    foreach (DbColumn col in dr.GetColumnSchema())
                    {
                        object val = dr[col.ColumnName];
                        dictionary.Add(col.ColumnName, val == DBNull.Value ? null : ((val is Guid) ? val.ToString() : val));
                    }
                    dictionary.Add("ErrorMsg", "");
                    objList.Add(dictionary);
                }
            }
            dr.Close();
            return objList.AsEnumerable<dynamic>();
        }

    }
}