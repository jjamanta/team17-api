 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class RankProfileService : _ServiceBase<RankProfile>, IRankProfileService
	{
		private readonly IRankProfileRepository m_RankProfileRepository;

		public RankProfileService(IRankProfileRepository rankprofileRepository)
			: base(rankprofileRepository)
		{
			m_RankProfileRepository = rankprofileRepository;
		}

		public IEnumerable<RankProfile> List()
		{
			m_RankProfileRepository.PersonId = this.PersonId;
			return m_RankProfileRepository.List();
		}

		public RankProfile List(int profileId)
		{
			m_RankProfileRepository.PersonId = this.PersonId;
			return m_RankProfileRepository.List(profileId);
		}
		public RankProfile Save(RankProfile objRankProfile)
		{
			m_RankProfileRepository.PersonId = this.PersonId;
			return m_RankProfileRepository.Save(objRankProfile);
		}

		public _ReturnProc Delete(int profileId)
		{
			m_RankProfileRepository.PersonId = this.PersonId;
			return m_RankProfileRepository.Delete(profileId);
		}
	}
}
