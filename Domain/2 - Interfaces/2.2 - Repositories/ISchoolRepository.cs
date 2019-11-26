
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface ISchoolRepository : _IRepositoryBase<School>
	{
		IEnumerable<School> List();

		School List(string schoolId);
		School Save(School objSchool);

		_ReturnProc Delete(string schoolId);
	}
}
