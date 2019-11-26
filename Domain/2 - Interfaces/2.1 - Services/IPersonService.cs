
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface IPersonService : _IServiceBase<Person>
	{
		IEnumerable<Person> List();

		Person List(string personId);
		Person Save(Person objPerson);
        Person Authenticate(string email, string password);

        _ReturnProc Delete(string personId);
	}
}
