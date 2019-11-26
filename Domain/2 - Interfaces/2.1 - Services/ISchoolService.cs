
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface ISchoolService : _IServiceBase<School>
	{
		IEnumerable<School> List();

		School List(string schoolId);
		School Save(School objSchool);

		_ReturnProc Delete(string schoolId);
	}
}
