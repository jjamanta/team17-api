 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class AddressService : _ServiceBase<Address>, IAddressService
	{
		private readonly IAddressRepository m_AddressRepository;

		public AddressService(IAddressRepository addressRepository)
			: base(addressRepository)
		{
			m_AddressRepository = addressRepository;
		}

		public IEnumerable<Address> List()
		{
			m_AddressRepository.PersonId = this.PersonId;
			return m_AddressRepository.List();
		}

		public Address List(string addressId)
		{
			m_AddressRepository.PersonId = this.PersonId;
			return m_AddressRepository.List(addressId);
		}
		public Address Save(Address objAddress)
		{
			m_AddressRepository.PersonId = this.PersonId;
			return m_AddressRepository.Save(objAddress);
		}

		public _ReturnProc Delete(string addressId)
		{
			m_AddressRepository.PersonId = this.PersonId;
			return m_AddressRepository.Delete(addressId);
		}
	}
}
