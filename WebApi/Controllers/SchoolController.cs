 
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
	public class SchoolController : _ApiBaseController
	{
		private readonly ISchoolService m_SchoolService;

		public SchoolController(ISchoolService schoolService)
		{
			m_SchoolService = schoolService;
		}

		[HttpGet]
		public IEnumerable<School> List()
		{
			m_SchoolService.PersonId = this.PersonId;
			return m_SchoolService.List();
		}

		[HttpGet("{id}")]
		public School List(string id)
		{
			m_SchoolService.PersonId = this.PersonId;
			return m_SchoolService.List(id);
		}
		[HttpPost]
		public School Save(School objSchool)
		{
			m_SchoolService.PersonId = this.PersonId;
			return m_SchoolService.Save(objSchool);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_SchoolService.PersonId = this.PersonId;
			return m_SchoolService.Delete(id);
		}
	}
}
