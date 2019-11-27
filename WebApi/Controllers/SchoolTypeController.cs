 
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
	public class SchoolTypeController : _ApiBaseController
	{
		private readonly ISchoolTypeService m_SchoolTypeService;

		public SchoolTypeController(ISchoolTypeService schooltypeService)
		{
			m_SchoolTypeService = schooltypeService;
		}

		[HttpGet]
		public IEnumerable<SchoolType> List()
		{
			m_SchoolTypeService.PersonId = this.PersonId;
			return m_SchoolTypeService.List();
		}

		[HttpGet("{id}")]
		public SchoolType List(string id)
		{
			m_SchoolTypeService.PersonId = this.PersonId;
			return m_SchoolTypeService.List(id);
		}
		[HttpPost]
		public SchoolType Save(SchoolType objSchoolType)
		{
			m_SchoolTypeService.PersonId = this.PersonId;
			return m_SchoolTypeService.Save(objSchoolType);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_SchoolTypeService.PersonId = this.PersonId;
			return m_SchoolTypeService.Delete(id);
		}
	}
}
