
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class SchoolTypeRepository : _RepositoryBase<SchoolType>, ISchoolTypeRepository
	{
		public SchoolTypeRepository(IConfiguration config) : base(config) { }

		public IEnumerable<SchoolType> List()
		{
			return ExecuteList("SchoolTypeList");
		}

		public SchoolType List(string schoolTypeId)
		{
			return ExecuteList("SchoolTypeList", new object[] {
					new SqlParameter("SchoolTypeId", schoolTypeId)
			}).FirstOrDefault();
		}
		public SchoolType Save(SchoolType objSchoolType)
		{
			_ReturnProc ret = ExecuteTuple("SchoolTypeSave", new object[] {
					new SqlParameter("SchoolTypeId", objSchoolType.SchoolTypeId),
					new SqlParameter("SchoolTypeDesc", objSchoolType.SchoolTypeDesc),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new SchoolType
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("SchoolTypeList", new object[] {
					new SqlParameter("SchoolTypeId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string schoolTypeId)
		{
			return ExecuteTuple("SchoolTypeDelete", new object[] {
					new SqlParameter("SchoolTypeId", schoolTypeId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
