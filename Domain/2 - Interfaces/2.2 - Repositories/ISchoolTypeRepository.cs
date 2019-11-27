
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface ISchoolTypeRepository : _IRepositoryBase<SchoolType>
	{
		IEnumerable<SchoolType> List();

		SchoolType List(string schoolTypeId);
		SchoolType Save(SchoolType objSchoolType);

		_ReturnProc Delete(string schoolTypeId);
	}
}
