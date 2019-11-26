 
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
	public class StudentController : _ApiBaseController
	{
		private readonly IStudentService m_StudentService;

		public StudentController(IStudentService studentService)
		{
			m_StudentService = studentService;
		}

		[HttpGet]
		public IEnumerable<Student> List()
		{
			m_StudentService.PersonId = this.PersonId;
			return m_StudentService.List();
		}

		[HttpGet("{id}")]
		public Student List(string id)
		{
			m_StudentService.PersonId = this.PersonId;
			return m_StudentService.List(id);
		}
		[HttpPost]
		public Student Save(Student objStudent)
		{
			m_StudentService.PersonId = this.PersonId;
			return m_StudentService.Save(objStudent);
		}

		[HttpDelete("{id}")]
		public _ReturnProc Delete(string id)
		{
			m_StudentService.PersonId = this.PersonId;
			return m_StudentService.Delete(id);
		}
	}
}
