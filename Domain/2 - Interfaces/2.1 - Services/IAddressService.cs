
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;

namespace Team17.Domain.Interfaces.Services
{
	public interface IAddressService : _IServiceBase<Address>
	{
		IEnumerable<Address> List();

		Address List(string addressId);
		Address Save(Address objAddress);

		_ReturnProc Delete(string addressId);
	}
}
