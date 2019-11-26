 
using System;
using System.Collections.Generic;
using Team17.Domain.Entities;
using Team17.Domain.Interfaces.Services;
using Team17.Domain.Interfaces.Repositories;

namespace Team17.Domain.Services
{
	public class StudentService : _ServiceBase<Student>, IStudentService
	{
		private readonly IStudentRepository m_StudentRepository;

		public StudentService(IStudentRepository studentRepository)
			: base(studentRepository)
		{
			m_StudentRepository = studentRepository;
		}

		public IEnumerable<Student> List()
		{
			m_StudentRepository.PersonId = this.PersonId;
			return m_StudentRepository.List();
		}

		public Student List(string studentId)
		{
			m_StudentRepository.PersonId = this.PersonId;
			return m_StudentRepository.List(studentId);
		}
		public Student Save(Student objStudent)
		{
			m_StudentRepository.PersonId = this.PersonId;
			return m_StudentRepository.Save(objStudent);
		}

		public _ReturnProc Delete(string studentId)
		{
			m_StudentRepository.PersonId = this.PersonId;
			return m_StudentRepository.Delete(studentId);
		}
	}
}
