
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class SchoolRepository : _RepositoryBase<School>, ISchoolRepository
	{
		public SchoolRepository(IConfiguration config) : base(config) { }

		public IEnumerable<School> List()
		{
			return ExecuteList("SchoolList");
		}

		public School List(string schoolId)
		{
			return ExecuteList("SchoolList", new object[] {
					new SqlParameter("SchoolId", schoolId)
			}).FirstOrDefault();
		}
		public School Save(School objSchool)
		{
			_ReturnProc ret = ExecuteTuple("SchoolSave", new object[] {
					new SqlParameter("SchoolId", objSchool.SchoolId),
					new SqlParameter("SchoolName", objSchool.SchoolName),
					new SqlParameter("AddressId", objSchool.AddressId),
					new SqlParameter("DirectorId", objSchool.DirectorId),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new School
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("SchoolList", new object[] {
					new SqlParameter("SchoolId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string schoolId)
		{
			return ExecuteTuple("SchoolDelete", new object[] {
					new SqlParameter("SchoolId", schoolId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
