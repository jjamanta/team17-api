 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class StudentAnwserService : _ServiceBase<StudentAnwser>, IStudentAnwserService
	{
		private readonly IStudentAnwserRepository m_StudentAnwserRepository;

		public StudentAnwserService(IStudentAnwserRepository studentanwserRepository)
			: base(studentanwserRepository)
		{
			m_StudentAnwserRepository = studentanwserRepository;
		}

		public IEnumerable<StudentAnwser> List()
		{
			m_StudentAnwserRepository.PersonId = this.PersonId;
			return m_StudentAnwserRepository.List();
		}

		public StudentAnwser List(int questionOptionId)
		{
			m_StudentAnwserRepository.PersonId = this.PersonId;
			return m_StudentAnwserRepository.List(questionOptionId);
		}
		public StudentAnwser Save(StudentAnwser objStudentAnwser)
		{
			m_StudentAnwserRepository.PersonId = this.PersonId;
			return m_StudentAnwserRepository.Save(objStudentAnwser);
		}

		public _ReturnProc Delete(int questionOptionId)
		{
			m_StudentAnwserRepository.PersonId = this.PersonId;
			return m_StudentAnwserRepository.Delete(questionOptionId);
		}
	}
}
