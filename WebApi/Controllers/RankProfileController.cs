 
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
	public class RankProfileController : _ApiBaseController
	{
		private readonly IRankProfileService m_RankProfileService;

		public RankProfileController(IRankProfileService rankprofileService)
		{
			m_RankProfileService = rankprofileService;
		}

		[HttpGet]
		public IEnumerable<RankProfile> List()
		{
			m_RankProfileService.PersonId = this.PersonId;
			return m_RankProfileService.List();
		}

		[HttpGet("{id}")]
		public RankProfile List(int id)
		{
			m_RankProfileService.PersonId = this.PersonId;
			return m_RankProfileService.List(id);
		}
		[HttpPost]
		public RankProfile Save(RankProfile objRankProfile)
		{
			m_RankProfileService.PersonId = this.PersonId;
			return m_RankProfileService.Save(objRankProfile);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(int id)
		{
			m_RankProfileService.PersonId = this.PersonId;
			return m_RankProfileService.Delete(id);
		}
	}
}
