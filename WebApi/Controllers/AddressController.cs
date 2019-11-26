 
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;

namespace Team17.Api.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AddressController : _ApiBaseController
	{
		private readonly IAddressService m_AddressService;

		public AddressController(IAddressService addressService)
		{
			m_AddressService = addressService;
		}

		[HttpGet]
		public IEnumerable<Address> List()
		{
			m_AddressService.PersonId = this.PersonId;
			return m_AddressService.List();
		}

		[HttpGet("{id}")]
		public Address List(string id)
		{
			m_AddressService.PersonId = this.PersonId;
			return m_AddressService.List(id);
		}
		[HttpPost]
		public Address Save(Address objAddress)
		{
			m_AddressService.PersonId = this.PersonId;
			return m_AddressService.Save(objAddress);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_AddressService.PersonId = this.PersonId;
			return m_AddressService.Delete(id);
		}
	}
}
