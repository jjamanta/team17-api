 
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
	public class PersonController : _ApiBaseController
	{
		private readonly IPersonService m_PersonService;

		public PersonController(IPersonService personService)
		{
			m_PersonService = personService;
		}

		[HttpGet]
		public IEnumerable<Person> List()
		{
			m_PersonService.PersonId = this.PersonId;
			return m_PersonService.List();
		}

		[HttpGet("{id}")]
		public Person List(string id)
		{
			m_PersonService.PersonId = this.PersonId;
			return m_PersonService.List(id);
		}
		[HttpPost]
		public Person Save(Person objPerson)
		{
			m_PersonService.PersonId = this.PersonId;
			return m_PersonService.Save(objPerson);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_PersonService.PersonId = this.PersonId;
			return m_PersonService.Delete(id);
		}
	}
}
