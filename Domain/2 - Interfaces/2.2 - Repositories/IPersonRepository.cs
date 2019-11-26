
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface IPersonRepository : _IRepositoryBase<Person>
	{
		IEnumerable<Person> List();
        Person Authenticate(string email, string password);

        Person List(string personId);
		Person Save(Person objPerson);

		_ReturnProc Delete(string personId);
	}
}
