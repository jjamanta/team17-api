
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface ISchoolTypeService : _IServiceBase<SchoolType>
	{
		IEnumerable<SchoolType> List();

		SchoolType List(string schoolTypeId);
		SchoolType Save(SchoolType objSchoolType);

		_ReturnProc Delete(string schoolTypeId);
	}
}
