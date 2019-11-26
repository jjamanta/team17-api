
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Repositories
{
	public interface IAddressRepository : _IRepositoryBase<Address>
	{
		IEnumerable<Address> List();

		Address List(string addressId);
		Address Save(Address objAddress);

		_ReturnProc Delete(string addressId);
	}
}
