 
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
	public class ProfileController : _ApiBaseController
	{
		private readonly IProfileService m_ProfileService;

		public ProfileController(IProfileService profileService)
		{
			m_ProfileService = profileService;
		}

		[HttpGet]
		public IEnumerable<Profile> List()
		{
			m_ProfileService.PersonId = this.PersonId;
			return m_ProfileService.List();
		}

		[HttpGet("{id}")]
		public Profile List(string id)
		{
			m_ProfileService.PersonId = this.PersonId;
			return m_ProfileService.List(id);
		}
		[HttpPost]
		public Profile Save(Profile objProfile)
		{
			m_ProfileService.PersonId = this.PersonId;
			return m_ProfileService.Save(objProfile);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_ProfileService.PersonId = this.PersonId;
			return m_ProfileService.Delete(id);
		}
	}
}
