 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class ProfileService : _ServiceBase<Profile>, IProfileService
	{
		private readonly IProfileRepository m_ProfileRepository;

		public ProfileService(IProfileRepository profileRepository)
			: base(profileRepository)
		{
			m_ProfileRepository = profileRepository;
		}

		public IEnumerable<Profile> List()
		{
			m_ProfileRepository.PersonId = this.PersonId;
			return m_ProfileRepository.List();
		}

		public Profile List(string profileId)
		{
			m_ProfileRepository.PersonId = this.PersonId;
			return m_ProfileRepository.List(profileId);
		}
		public Profile Save(Profile objProfile)
		{
			m_ProfileRepository.PersonId = this.PersonId;
			return m_ProfileRepository.Save(objProfile);
		}

		public _ReturnProc Delete(string profileId)
		{
			m_ProfileRepository.PersonId = this.PersonId;
			return m_ProfileRepository.Delete(profileId);
		}
	}
}
