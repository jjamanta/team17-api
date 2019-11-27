 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class SchoolTypeService : _ServiceBase<SchoolType>, ISchoolTypeService
	{
		private readonly ISchoolTypeRepository m_SchoolTypeRepository;

		public SchoolTypeService(ISchoolTypeRepository schooltypeRepository)
			: base(schooltypeRepository)
		{
			m_SchoolTypeRepository = schooltypeRepository;
		}

		public IEnumerable<SchoolType> List()
		{
			m_SchoolTypeRepository.PersonId = this.PersonId;
			return m_SchoolTypeRepository.List();
		}

		public SchoolType List(string schoolTypeId)
		{
			m_SchoolTypeRepository.PersonId = this.PersonId;
			return m_SchoolTypeRepository.List(schoolTypeId);
		}
		public SchoolType Save(SchoolType objSchoolType)
		{
			m_SchoolTypeRepository.PersonId = this.PersonId;
			return m_SchoolTypeRepository.Save(objSchoolType);
		}

		public _ReturnProc Delete(string schoolTypeId)
		{
			m_SchoolTypeRepository.PersonId = this.PersonId;
			return m_SchoolTypeRepository.Delete(schoolTypeId);
		}
	}
}
