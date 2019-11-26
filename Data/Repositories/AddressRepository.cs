
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Data.Repositories
{
	public class AddressRepository : _RepositoryBase<Address>, IAddressRepository
	{
		public AddressRepository(IConfiguration config) : base(config) { }

		public IEnumerable<Address> List()
		{
			return ExecuteList("AddressList");
		}

		public Address List(string addressId)
		{
			return ExecuteList("AddressList", new object[] {
					new SqlParameter("AddressId", addressId)
			}).FirstOrDefault();
		}
		public Address Save(Address objAddress)
		{
			_ReturnProc ret = ExecuteTuple("AddressSave", new object[] {
					new SqlParameter("AddressId", objAddress.AddressId),
					new SqlParameter("Line1", objAddress.Line1),
					new SqlParameter("Line2", objAddress.Line2),
					new SqlParameter("Neighbourhood", objAddress.Neighbourhood),
					new SqlParameter("City", objAddress.City),
					new SqlParameter("State", objAddress.State),
					new SqlParameter("ZipCode", objAddress.ZipCode),
					new SqlParameter("Latitude", objAddress.Latitude),
					new SqlParameter("Longitude", objAddress.Longitude),
					new SqlParameter("CountryId", objAddress.CountryId),
					new SqlParameter("PersonId", this.PersonId)
			});

			if (!ret.IsValid)
			{
				return new Address
				{
					ErrorMsg = ret.ErrorMsg
				};
			}

			return ExecuteList("AddressList", new object[] {
					new SqlParameter("AddressId", ret.GetValue())
			}).FirstOrDefault();
		}
		public _ReturnProc Delete(string addressId)
		{
			return ExecuteTuple("AddressDelete", new object[] {
					new SqlParameter("AddressId", addressId),
					new SqlParameter("PersonId", this.PersonId)
			});
		}

	}
}
