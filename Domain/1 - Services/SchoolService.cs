 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class SchoolService : _ServiceBase<School>, ISchoolService
	{
		private readonly ISchoolRepository m_SchoolRepository;

		public SchoolService(ISchoolRepository schoolRepository)
			: base(schoolRepository)
		{
			m_SchoolRepository = schoolRepository;
		}

		public IEnumerable<School> List()
		{
			m_SchoolRepository.PersonId = this.PersonId;
			return m_SchoolRepository.List();
		}

		public School List(string schoolId)
		{
			m_SchoolRepository.PersonId = this.PersonId;
			return m_SchoolRepository.List(schoolId);
		}
		public School Save(School objSchool)
		{
			m_SchoolRepository.PersonId = this.PersonId;
			return m_SchoolRepository.Save(objSchool);
		}

		public _ReturnProc Delete(string schoolId)
		{
			m_SchoolRepository.PersonId = this.PersonId;
			return m_SchoolRepository.Delete(schoolId);
		}
	}
}
